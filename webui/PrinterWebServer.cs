using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeUI.program.util;
using Newtonsoft.Json;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI.webui
{
    public class PrinterWebServer
    {
        private HttpListener _httpListener;
        private readonly MainMenu _ui;
        private readonly WebServerBridge _serverBridge;
        private readonly WebSocketHandler _webSocketHandler;
        private readonly string _baseDirectory;
        private readonly string _printerIp;
        //private readonly Config _config;
        public bool Running = false;

        public PrinterWebServer(MainMenu ui, Config config)
        {
            _ui = ui;
            //_config = config;
            _serverBridge = new WebServerBridge(ui.PrinterClient);
            _webSocketHandler = new WebSocketHandler(ui, _serverBridge, config);
            _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "webui//wwwroot");
            _printerIp = ui.PrinterClient.IpAddress;

            Debug.WriteLine($"PrinterWebServer initialized with base directory: {_baseDirectory}");
            Debug.WriteLine($"Printer IP Address: {_printerIp}");
        }

        public void Start()
        {
            try
            {
                _httpListener = new HttpListener();
                _httpListener.Prefixes.Add("http://*:8080/");
                _httpListener.Start();

                var localIpAddresses = string.Join(", ", GetLocalIpAddresses());
                _ui.AppendLog($"Web server started on IP(s): {localIpAddresses}, port 8080");
                Running = true;

                // Start WebSocket status updates
                _webSocketHandler.StartStatusUpdates();

                // Start listening for connections in the background
                Task.Run(async () =>
                {
                    while (_httpListener.IsListening)
                    {
                        try
                        {
                            // Get the next request
                            var context = await _httpListener.GetContextAsync();

                            // Handle the request in a new task so we can immediately continue listening
                            _ = Task.Run(async () =>
                            {
                                try
                                {
                                    if (context.Request.IsWebSocketRequest && context.Request.Url.AbsolutePath == "/ws")
                                        await HandleWebSocketRequest(context);
                                    else await HandleHttpRequest(context);
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine($"Error handling request: {ex.Message}");
                                    Debug.WriteLine(ex.StackTrace);
                                    try
                                    {
                                        context.Response.StatusCode = 500;
                                        context.Response.Close();
                                    }
                                    catch
                                    {
                                        /* ignore cleanup errors */
                                    }
                                }
                            });
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error accepting request: {ex.Message}");
                            Debug.WriteLine(ex.StackTrace);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unable to start web server: {e.Message}");
                MessageBox.Show("Unable to start web server (for web UI), did you run as administrator?",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Running = false;
            }
        }

        private async Task HandleWebSocketRequest(HttpListenerContext context)
        {
            try
            {
                WebSocketContext webSocketContext = null;
                try
                {
                    webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
                    Debug.WriteLine("WebSocket connection accepted");
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"WebSocket upgrade failed: {e.Message}");
                    context.Response.StatusCode = 500;
                    context.Response.Close();
                    return;
                }

                using (var ws = webSocketContext.WebSocket)
                {
                    await _webSocketHandler.HandleWebSocketConnection(ws);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error handling WebSocket request: {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
                context.Response.StatusCode = 500;
                context.Response.Close();
            }
        }

        private async Task HandleHttpRequest(HttpListenerContext context)
        {
            try
            {
                if (context.Request.IsWebSocketRequest)
                {
                    if (context.Request.Url.AbsolutePath == "/ws")
                    {
                        await HandleWebSocketRequest(context);
                        return;
                    }

                    context.Response.StatusCode = 400;
                    context.Response.Close();
                    return;
                }

                var request = context.Request;
                var response = context.Response;

                try
                {
                    string path = request.Url.AbsolutePath;

                    // Serve index.html for root path
                    if (path == "/" || string.IsNullOrEmpty(path)) path = "/index.html";

                    // Convert path to use correct directory separators and remove any leading separator
                    var normalizedPath = path.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
                    var fullPath = Path.GetFullPath(Path.Combine(_baseDirectory, normalizedPath));

                    Debug.WriteLine($"Requested path: {path}");
                    Debug.WriteLine($"Full path: {fullPath}");
                    Debug.WriteLine($"Base directory: {_baseDirectory}");

                    if (!File.Exists(fullPath))
                    {
                        Debug.WriteLine($"File not found: {fullPath}");
                        response.StatusCode = 404;
                        response.Close();
                        return;
                    }

                    // Serve html (and replace printer webcam ip placeholder - custom camera will be loaded from config)
                    if (Path.GetFileName(fullPath).Equals("index.html", StringComparison.OrdinalIgnoreCase))
                    {
                        var content = File.ReadAllText(fullPath);
                        if (_ui.Config.CustomCamera)
                        {
                            var url = _ui.Config.CustomCameraUrl.Replace("{IpAddress}", _ui.PrinterClient.IpAddress);
                            content = content.Replace("STREAM_URL_PLACEHOLDER", url);
                        } else content = content.Replace("STREAM_URL_PLACEHOLDER", $"http://{_ui.PrinterClient.IpAddress}:8080/?action=stream");
                        var buffer = Encoding.UTF8.GetBytes(content);
                        response.ContentType = "text/html";
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        // Serve all other static files
                        var content = File.ReadAllBytes(fullPath);
                        response.ContentType = GetContentType(Path.GetExtension(fullPath));
                        response.ContentLength64 = content.Length;
                        await response.OutputStream.WriteAsync(content, 0, content.Length);
                    }
                }
                finally
                {
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error handling HTTP request: {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
                context.Response.StatusCode = 500;
                context.Response.Close();
            }
        }

        private static string GetContentType(string extension)
        {
            switch (extension.ToLower())
            {
                case ".html": return "text/html";
                case ".css": return "text/css";
                case ".js": return "application/javascript";
                case ".png": return "image/png";
                case ".jpg":
                case ".jpeg": return "image/jpeg";
                case ".gif": return "image/gif";
                case ".svg": return "image/svg+xml";
                case ".ico": return "image/x-icon";
                case ".json": return "application/json";
                default: return "application/octet-stream";
            }
        }

        private static IEnumerable<string> GetLocalIpAddresses()
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .Where(ip => ip.ToString().Contains("192.168"))
                .Select(ip => ip.ToString());
        }

        public void Stop()
        {
            if (!Running) return;

            try
            {
                _webSocketHandler.StopStatusUpdates();

                if (_httpListener?.IsListening == true)
                {
                    _httpListener.Stop();
                    _httpListener.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping web server: {ex.Message}");
            }
            finally
            {
                Running = false;
                _ui.AppendLog("Web server stopped.");
            }
        }
    }
}