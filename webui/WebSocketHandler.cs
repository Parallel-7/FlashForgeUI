using System;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using FlashForgeUI.program.util;
using FlashForgeUI.ui.main;

namespace FlashForgeUI.webui
{
    public class WebSocketHandler
    {
        private readonly ConcurrentDictionary<string, WebSocket> _clients = new ConcurrentDictionary<string, WebSocket>();
        private readonly MainMenu _ui;
        private readonly WebServerBridge _serverBridge;
        private readonly Config _config;
        private CancellationTokenSource _statusUpdateCts;
        private Task _statusUpdateTask;

        public WebSocketHandler(MainMenu ui, WebServerBridge serverBridge, Config config)
        {
            _ui = ui;
            _serverBridge = serverBridge;
            _config = config;
        }

        public async Task HandleWebSocketConnection(WebSocket webSocket)
        {
            var clientId = Guid.NewGuid().ToString();
        
            try
            {
                if (webSocket.State == WebSocketState.Open)
                {
                    _clients.TryAdd(clientId, webSocket);
                    Debug.WriteLine($"New client connected: {clientId}. Total clients: {_clients.Count}");
                    
                    await SendConfig(webSocket);
                    await SendStatus(webSocket);
                    await ReceiveMessages(webSocket, clientId);
                }
            }
            catch (Exception ex) { Debug.WriteLine($"WebSocket error for client {clientId}: {ex.Message}"); }
            finally
            {
                // Clean up when client disconnects
                if (_clients.TryRemove(clientId, out var socket))
                {
                    Debug.WriteLine($"Client disconnected: {clientId}. Remaining clients: {_clients.Count}");
                
                    if (socket.State == WebSocketState.Open)
                    {
                        try
                        {
                            await socket.CloseAsync(
                                WebSocketCloseStatus.NormalClosure,
                                "Connection closed by server",
                                CancellationToken.None);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error closing socket for client {clientId}: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async Task SendConfig(WebSocket webSocket)
        {

            var configMessage = new
            {
                type = "config",
                data = new
                {
                    webUi = _config.WebUi,
                    debugMode = _config.DebugMode,
                    customCamera = _config.CustomCamera,
                    customCameraUrl = _config.CustomCameraUrl,
                    discordSync = _config.DiscordSync
                }
            };

            await SendJsonMessage(webSocket, configMessage);
        }

        private async Task SendStatus(WebSocket webSocket)
        {
            var status = _ui.UiHelper.GetPrinterStatusJson();
            var statusMessage = new
            {
                type = "status",
                data = status
            };

            await SendJsonMessage(webSocket, statusMessage);
        }

        public void StartStatusUpdates()
        {
            _statusUpdateCts = new CancellationTokenSource();
            _statusUpdateTask = Task.Run(async () =>
            {
                while (!_statusUpdateCts.Token.IsCancellationRequested)
                {
                    try
                    {
                        await BroadcastStatus();
                        await Task.Delay(1000, _statusUpdateCts.Token);
                    }
                    catch (OperationCanceledException) { break; }
                    catch (Exception ex) { Debug.WriteLine($"Error in status update: {ex.Message}"); }
                }
            }, _statusUpdateCts.Token);
        }

        private async Task BroadcastStatus()
        {
            var status = _ui.UiHelper.GetPrinterStatusJson();
            var statusMessage = new
            {
                type = "status",
                data = status
            };

            await BroadcastMessage(statusMessage);
        }

        public void StopStatusUpdates()
        {
            _statusUpdateCts?.Cancel();
            _statusUpdateTask?.Wait();
        }

        private async Task ReceiveMessages(WebSocket webSocket, string clientId)
        {
            var buffer = new byte[1024 * 4];

            while (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
                            "Closing as per client request", 
                            CancellationToken.None);
                    }
                    else if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        await ProcessClientMessage(message, webSocket);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error receiving message from client {clientId}: {ex.Message}");
                    break;
                }
            }
        }

        private async Task ProcessClientMessage(string message, WebSocket socket)
        {
            try
            {
                var command = JsonConvert.DeserializeObject<dynamic>(message);
                string result = "Unknown command";

                switch ((string)command.type)
                {
                    case "command":
                        result = await ProcessPrinterCommand(command);
                        break;
                    case "getFiles":
                        await SendFileList(socket, (string)command.parameters.listType);
                        return;
                    case "getThumbnail":
                        await SendThumbnail(socket, (string)command.parameters.filename);
                        return;
                }

                await SendJsonMessage(socket, new { type = "response", data = result });
            }
            catch (Exception ex)
            {
                await SendJsonMessage(socket, new { type = "error", message = ex.Message });
            }
        }

        private async Task<string> ProcessPrinterCommand(dynamic command)
        {
            string cmdName = command.command;
            var parameters = command.parameters;

            switch (cmdName)
            {
                case "clearStatus":
                    return await _serverBridge.ClearStatus();
                case "pauseJob":
                    return await _serverBridge.PauseJob();
                case "resumeJob":
                    return await _serverBridge.ResumeJob();
                case "stopJob":
                    return await _serverBridge.StopJob();
                case "homeAxes":
                    return await _serverBridge.HomeAxes();
                case "setCoolingFanSpeed":
                    return await _serverBridge.SetCoolingFanSpeed((int)parameters.speed);
                case "setChamberFanSpeed":
                    return await _serverBridge.SetChamberFanSpeed((int)parameters.speed);
                case "setBedTemp":
                    return await _serverBridge.SetBedTemperature((int)parameters.temp);
                case "setExtruderTemp":
                    return await _serverBridge.SetExtruderTemperature((int)parameters.temp);
                case "setZAxisOffset":
                    return await _serverBridge.SetZAxisOffset((float)parameters.offset);
                case "turnLedOn":
                    return await _serverBridge.SetLedOn();
                case "turnLedOff":
                    return await _serverBridge.SetLedOff();
                case "cancelBedHeating":
                    return await _serverBridge.CancelBedHeating();
                case "cancelExtruderHeating":
                    return await _serverBridge.CancelExtruderHeating();
                case "setExternalFiltrationOn":
                    return await _serverBridge.SetExternalFiltrationOn();
                case "setInternalFiltrationOn":
                    return await _serverBridge.SetInternalFiltrationOn();
                case "setFiltrationOff":
                    return await _serverBridge.SetFiltrationOff();
                case "startLocalJob":
                    return await _serverBridge.StartLocalJob(
                        (string)parameters.filename,
                        (bool)parameters.autoLevel
                    );
                default:
                    return $"Unknown command: {cmdName}";
            }
        }

        private async Task SendFileList(WebSocket socket, string listType)
        {
            try
            {
                var files = await _serverBridge.GetGCodeFileList(listType);
                await SendJsonMessage(socket, new { type = "fileList", data = files });
            }
            catch (Exception ex)
            {
                await SendJsonMessage(socket, new { type = "error", message = $"Error getting file list: {ex.Message}" });
            }
        }

        private async Task SendThumbnail(WebSocket socket, string filename)
        {
            try
            {
                var thumbnailData = await _serverBridge.GetGCodeThumbnail(filename);
                if (thumbnailData != null)
                {
                    var base64Data = Convert.ToBase64String(thumbnailData);
                    await SendJsonMessage(socket, new { type = "thumbnail", filename = filename, data = base64Data });
                }
                else
                {
                    await SendJsonMessage(socket, new { type = "error", message = "Thumbnail not found" });
                }
            }
            catch (Exception ex)
            {
                await SendJsonMessage(socket, new { type = "error", message = $"Error getting thumbnail: {ex.Message}" });
            }
        }

        private async Task SendJsonMessage(WebSocket socket, object message)
        {
            if (socket.State != WebSocketState.Open) return;

            var json = JsonConvert.SerializeObject(message);
            var bytes = Encoding.UTF8.GetBytes(json);
            await socket.SendAsync(new ArraySegment<byte>(bytes), 
                WebSocketMessageType.Text, 
                true, 
                CancellationToken.None);
        }

        private async Task BroadcastMessage(object message)
        {
            var deadSockets = new ConcurrentBag<string>();

            foreach (var client in _clients)
            {
                try
                {
                    if (client.Value.State == WebSocketState.Open)
                    {
                        await SendJsonMessage(client.Value, message);
                    }
                    else
                    {
                        deadSockets.Add(client.Key);
                    }
                }
                catch (Exception)
                {
                    deadSockets.Add(client.Key);
                }
            }

            foreach (var id in deadSockets)
            {
                _clients.TryRemove(id, out _);
            }
        }
    }
}