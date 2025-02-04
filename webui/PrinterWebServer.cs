using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI.webui
{
    public class PrinterWebServer
    {
        private HttpListener _httpListener;
        private readonly MainMenu _ui;
        private readonly WebServerBridge _serverBridge;
        private readonly string _baseDirectory;
        private readonly string printerIp;
        public bool Running = false;

        public PrinterWebServer(MainMenu ui)
        {
            _ui = ui;
            _serverBridge = new WebServerBridge(ui.printerClient);
            _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "webui//wwwroot");
            printerIp = ui.printerClient.IpAddress;

            Debug.WriteLine($"PrinterWebServer initialized with base directory: {_baseDirectory}");
            Debug.WriteLine($"Printer IP Address: {printerIp}");
        }

        public void Start()
        {
            Debug.WriteLine("Starting web server");
            try
            {
                _httpListener = new HttpListener();
                _httpListener.Prefixes.Add("http://*:8080/"); // Listen on all network interfaces, port 8080
                _httpListener.Start();
            }
            catch (Exception e)
            {
                Debug.Write("Unable to start web server, probably not executed as admin:\n" + e.StackTrace);
                MessageBox.Show("Unable to start web server (for web UI), did you run as administrator?", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                Running = false;
                return;
            }

            // Get local IP addresses
            var localIpAddresses = string.Join(", ", GetLocalIpAddresses());
            _ui.AppendLog($"Web server started on IP(s): {localIpAddresses}, port 8080.");
            Running = true;

            Task.Run(async () =>
            {
                while (_httpListener.IsListening)
                {
                    try
                    {
                        var context = await _httpListener.GetContextAsync();
                        await ProcessWebRequest(context);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error processing request: " + ex.Message);
                    }
                }
            });
        }

        private static IEnumerable<string> GetLocalIpAddresses()
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                .Where(ip => ip.ToString().Contains("192.168"))
                .Select(ip => ip.ToString());
        }

        public void Stop()
        {
            if (!Running) return;
            Debug.WriteLine("Stopping web server");
            if (_httpListener == null || !_httpListener.IsListening) return;
            _httpListener.Stop();
            _httpListener.Close();
            Console.WriteLine("Web server stopped");
            Running = false;
            _ui.AppendLog("Web server stopped.");
        }

        private async Task ProcessWebRequest(HttpListenerContext context)
        {
            var response = context.Response;
            var request = context.Request;

            if (request.RawUrl.StartsWith("/status")) ServeStatusJson(response);
            else if (request.RawUrl.StartsWith("/files")) await ServeGCodeFileList(request, response);
            else if (request.RawUrl.StartsWith("/thumbnails/")) await ServeThumbnail(request, response);
            else if (request.RawUrl.StartsWith("/command")) await ProcessCommand(context);
            else await ServeStaticFile(request, response);
            // no need for anything else, web ui will never request anything out of parameters
        }

        private async Task ServeStaticFile(HttpListenerRequest request, HttpListenerResponse response)
        {
            var urlPath = request.Url.AbsolutePath;
            
            if (urlPath == "/") urlPath = "/index.html"; // default to index.html
            
            var safePath = Path.GetFullPath(Path.Combine(_baseDirectory, // Prevent directory traversal attacks
                urlPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)));
            
            if (File.Exists(safePath))
            {
                try
                {
                    if (Path.GetFileName(safePath).Equals("index.html", StringComparison.OrdinalIgnoreCase))
                    { 
                        var htmlContent = File.ReadAllText(safePath, Encoding.UTF8);
                        Debug.WriteLine($"Original HTML Content Length: {htmlContent.Length}");
                        htmlContent = htmlContent.Replace("REPLACE_PRINTER_IP", printerIp);
                        Debug.WriteLine($"Modified HTML Content Length: {htmlContent.Length}");

                        var buffer = Encoding.UTF8.GetBytes(htmlContent);
                        response.ContentType = "text/html";
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                        Debug.WriteLine("Served modified index.html");
                    }
                    else
                    {
                        var fileBytes = File.ReadAllBytes(safePath);
                        response.ContentType = GetContentType(Path.GetExtension(safePath));
                        response.ContentLength64 = fileBytes.Length;
                        await response.OutputStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                        Debug.WriteLine($"Served static file: {Path.GetFileName(safePath)}");
                    }

                    response.OutputStream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error serving static file: " + ex.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Close();
                }
            }
            else
            {
                // 404
                Debug.WriteLine($"File not found: {safePath}");
                response.StatusCode = (int) HttpStatusCode.NotFound;
                response.Close();
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
                case ".jpg": case ".jpeg": return "image/jpeg";
                case ".gif": return "image/gif";
                case ".svg": return "image/svg+xml";
                case ".json": return "application/json";
                default: return "application/octet-stream";
            }
        }

        private void ServeStatusJson(HttpListenerResponse response)
        {
            var status = _ui.GetPrinterStatus();
            var jsonResponse = JsonConvert.SerializeObject(status);
            var buffer = Encoding.UTF8.GetBytes(jsonResponse);
            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }

        private async Task ServeGCodeFileList(HttpListenerRequest request, HttpListenerResponse response)
        {
            var queryParams = request.QueryString;
            var listType = queryParams["listType"] ?? "recent"; // default to 'recent' if not specified

            List<string> files;
            if (listType == "local") files = await _serverBridge.GetGCodeFileList("local");
            else files = await _serverBridge.GetGCodeFileList("recent");

            // Convert the list to JSON
            var jsonResponse = JsonConvert.SerializeObject(files);
            var buffer = Encoding.UTF8.GetBytes(jsonResponse);
            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }

        private async Task ServeThumbnail(HttpListenerRequest request, HttpListenerResponse response)
        {
            var filename = Uri.UnescapeDataString(request.Url.AbsolutePath.Replace("/thumbnails/", ""));
            var thumbnailData = await _serverBridge.GetGCodeThumbnail(filename);

            if (thumbnailData != null)
            {
                response.ContentType = "image/png";
                response.ContentLength64 = thumbnailData.Length;
                await response.OutputStream.WriteAsync(thumbnailData, 0, thumbnailData.Length);
                response.OutputStream.Close();
            }
            else
            {
                response.StatusCode = 404;
                response.Close();
            }
        }

        private async Task ProcessCommand(HttpListenerContext context)
        {
            var request = context.Request;
            var command = request.Url.AbsolutePath.Replace("/command/", "");
            var response = context.Response;
            var queryParams = request.QueryString; // read params
            string result;

            switch (command)
            {
                case "pauseJob":
                    result = await _serverBridge.PauseJob();
                    break;
                case "resumeJob":
                    result = await _serverBridge.ResumeJob();
                    break;
                case "stopJob":
                    result = await _serverBridge.StopJob();
                    break;
                case "uploadJob":
                    //todo impl
                    result = "Upload job not implemented.";
                    break;
                case "homeAxes":
                    result = await _serverBridge.HomeAxes();
                    break;
                case "setCoolingFanSpeed":
                    result = await HandleSetCoolingFanSpeed(queryParams);
                    break;
                case "setChamberFanSpeed":
                    result = await HandleSetChamberFanSpeed(queryParams);
                    break;
                case "setBedTemp":
                    result = await HandleSetBedTemp(queryParams);
                    break;
                case "setExtruderTemp":
                    result = await HandleSetExtruderTemp(queryParams);
                    break;
                case "setZAxisOffset":
                    result = await HandleSetZAxisOffset(queryParams);
                    break;
                case "turnLedOn":
                    result = await _serverBridge.SetLedOn();
                    break;
                case "turnLedOff":
                    result = await _serverBridge.SetLedOff();
                    break;
                case "cancelBedHeating":
                    result = await _serverBridge.CancelBedHeating();
                    break;
                case "cancelExtruderHeating":
                    result = await _serverBridge.CancelExtruderHeating();
                    break;
                case "setExternalFiltrationOn":
                    result = await _serverBridge.SetExternalFiltrationOn();
                    break;
                case "setInternalFiltrationOn":
                    result = await _serverBridge.SetInternalFiltrationOn();
                    break;
                case "setFiltrationOff":
                    result = await _serverBridge.SetFiltrationOff();
                    break;
                case "startLocalJob":
                    result = await HandleStartLocalJob(request);
                    break;
                default:
                    result = "Unknown command.";
                    break;
            }

            // Send response
            var buffer = Encoding.UTF8.GetBytes(result);
            response.ContentType = "text/plain";
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }

        // Helper methods for handling commands with parameters
        private async Task<string> HandleSetCoolingFanSpeed(
            System.Collections.Specialized.NameValueCollection queryParams)
        {
            if (!await _serverBridge.IsPrinting()) return "Not available unless printing.";
            var speedParam = queryParams["speed"];
            if (int.TryParse(speedParam, out var speed)) return await _serverBridge.SetCoolingFanSpeed(speed);
            return "Invalid cooling fan speed.";
        }

        private async Task<string> HandleSetChamberFanSpeed(
            System.Collections.Specialized.NameValueCollection queryParams)
        {
            if (!await _serverBridge.IsPrinting()) return "Not available unless printing.";
            var speedParam = queryParams["speed"];
            if (int.TryParse(speedParam, out var speed)) return await _serverBridge.SetChamberFanSpeed(speed);
            return "Invalid chamber fan speed.";
        }

        private async Task<string> HandleSetBedTemp(System.Collections.Specialized.NameValueCollection queryParams)
        {
            if (await _serverBridge.IsPrinting()) return "Not available while printing.";
            var tempParam = queryParams["temp"];
            if (int.TryParse(tempParam, out var temp)) return await _serverBridge.SetBedTemperature(temp);
            return "Invalid bed temperature.";
        }

        private async Task<string> HandleSetExtruderTemp(System.Collections.Specialized.NameValueCollection queryParams)
        {
            if (!await _serverBridge.IsPrinting()) return "Not available while printing.";
            var tempParam = queryParams["temp"];
            if (int.TryParse(tempParam, out var temp)) return await _serverBridge.SetExtruderTemperature(temp);
            return "Invalid extruder temperature.";
        }

        private async Task<string> HandleSetZAxisOffset(System.Collections.Specialized.NameValueCollection queryParams)
        {
            if (!await _serverBridge.IsPrinting()) return "Not available unless printing.";
            var offsetParam = queryParams["offset"];
            if (float.TryParse(offsetParam, out var offset)) return await _serverBridge.SetZAxisOffset(offset);
            return "Invalid Z-axis offset.";
        }

        private async Task<string> HandleStartLocalJob(HttpListenerRequest request)
        {
            if (!await _serverBridge.IsReady()) return "Printer is busy."; // make sure the printer is ready
            var queryParams = request.QueryString;
            var filename = queryParams["filename"];
            var autoLevelParam = queryParams["autoLevel"];
            var autoLevel = bool.TryParse(autoLevelParam, out var tempAutoLevel) && tempAutoLevel;
            if (string.IsNullOrEmpty(filename)) return "No file specified.";
            var result = await _serverBridge.StartLocalJob(filename, autoLevel);
            return result;
        }
    }
}
