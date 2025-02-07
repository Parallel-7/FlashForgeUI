using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using FiveMApi.api;
using FlashForgeUI.manager;
using FlashForgeUI.program.util;
using FlashForgeUI.ui.main.manager;
using FlashForgeUI.ui.main.manager.camera;
using FlashForgeUI.ui.main.util;
using FlashForgeUI.webui;
using Microsoft.VisualBasic;

namespace FlashForgeUI.ui.main
{
    public partial class MainMenu : Form
    {
        // todo revert the custom listview (for log) back to standard win forms
        // and theme accordingly if we cannot get the scroll to bottom to work
        // it does look nicer though.
        
        internal MJPEGStream MjpegStream;

        public FiveMClient PrinterClient;

        internal PrinterWebServer WebServer;

        internal WebhookHelper Webhook;

        internal Config Config;
        
        
        // Managers
        private ConnectionManager _connectionManager;
        private StatusTimerManager _statusTimerManager;
        
        internal MjpegStreamManager MjpegStreamManager;
        internal ButtonManager ButtonManager;

        private UiHelper _uiHelper;
        
        
        public MjpegStreamManager GetCameraStreamManager()
        { // for WebhookHelper (sending preview image to discord)
            return MjpegStreamManager;
        }

        internal bool IsConnected;

        public MainMenu()
        {
            InitializeComponent();
            
            // hook form events
            Shown += MainMenu_Shown;
            FormClosed += MainMenu_Closed;
            
            // hook timer events
            timerStatusUpdate.Tick += timerStatusUpdate_Tick;
            timerSyncInfo.Tick += timerSyncInfo_Tick;
            timerSyncDiscord.Tick += timerSyncDiscord_Tick;
        }

        
        private void InitWebhook()
        {
            if (string.IsNullOrEmpty(Config.WebhookUrl))
            {
                MessageBox.Show("Invalid (or missing) webhook url in config.json! Discord sync disabled");
                return;
            }
            Webhook = new WebhookHelper(Config.WebhookUrl, this);
        }
        
        private void StartTimers()
        {
            timerStatusUpdate_Tick(null, null); // 'kick start' before first timer elapses
            timerSyncInfo_Tick(null, null);
            timerStatusUpdate.Start();
            timerSyncInfo.Start();
            if (Config.DiscordSync) timerSyncDiscord.Start();
            if (PrinterClient.IsPro || Config.CustomCamera && !string.IsNullOrEmpty(Config.CustomCameraUrl)) ButtonManager.PreviewOn();
        }

        private void StartWebUi()
        {
            WebServer = new PrinterWebServer(this, Config);
            WebServer.Start();
        }

        private void CheckFeatures()
        {
            if (!Compat.Is313OrAbove(PrinterClient.FirmVer))
            {
                AppendLog("This printer is running older firmware, some features may not be available, or work as intended. " +
                          "Please update to the latest firmware when possible for better compatibility");
                clearPlatformButton.Visible = false;
            }
            
            if (!PrinterClient.LedControl)
            {
                AppendLog("LEDs are not equipped or properly configured on this printer.");
                ledOffButton.Visible = false;
                ledOnButton.Visible = false;
            }

            if (PrinterClient.FiltrationControl) return;
            AppendLog("Filtration control is not available for this printer.");
            filtrationPanel.Visible = false;
            setChamberFanButton.Visible = false;
            chamberFanLabel.Visible = false;
        }
        
        
        // Timer Events
        private async void timerSyncDiscord_Tick(object sender, EventArgs e)
        {
            Debug.Write("Ticking SyncDiscord");
            await Webhook.SendStatus(PrinterClient); // todo handle result?
        }
        
        private async void timerSyncInfo_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Ticking SyncInfo");
            var info = await PrinterClient.Info.Get();
            PrinterClient.CacheDetails(info);
        }
        
        private async void timerStatusUpdate_Tick(object sender, EventArgs e)
        {
            await _statusTimerManager.TickStatusUpdate();
        }
        
        
        internal void AppendLog(string message)
        {
            Debug.WriteLine($"AppendLog called: {message}");
    
            if (logBox.InvokeRequired) logBox.Invoke(new Action(() => AddLogMessage(message)));
            else AddLogMessage(message);
        }

        private void AddLogMessage(string message)
        {
            try
            {
                var timeStampedMessage = $"{DateTime.Now:HH:mm:ss} - {message}";
                var currentItems = logBox.Items.ToList();
                currentItems.Add(timeStampedMessage);
                logBox.Items = currentItems.ToArray();
                logBox.SelectedIndex = logBox.Items.Length - 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding log message: {ex}");
            }
        }
        
        private async Task<bool> CheckJobReady()
        {
            var info = await PrinterClient.Info.Get();
            switch (info.Status)
            {
                case "ready":
                    return true;
                case "busy":
                    MessageBox.Show(
                        "You need to clear the cancelled print job (on the printer) before starting a new job.");
                    break;
                case "printing":
                    MessageBox.Show("There is an active job..", "Job in progress");
                    break;
                case "completed":
                    MessageBox.Show("Clear the print bed first!", "Print bed occupied");
                    break;
            }

            return false;
        }
        
        private string _lastJobFileName;

        internal async Task UpdateModelPreview(string currentJobFileName)
        { // todo possibly relocate to UiHelper?
            if (!string.IsNullOrEmpty(currentJobFileName))
            {
                if (currentJobFileName != _lastJobFileName)
                {
                    _lastJobFileName = currentJobFileName;

                    // Fetch the thumbnail
                    var thumbnailBytes = await PrinterClient.Files.GetGCodeThumbnail(currentJobFileName);
                    if (thumbnailBytes != null && thumbnailBytes.Length > 0)
                    {
                        using (var ms = new MemoryStream(thumbnailBytes))
                        {
                            var image = Image.FromStream(ms);
                            if (modelPreviewImg.InvokeRequired)
                            {
                                modelPreviewImg.Invoke(new Action(() =>
                                {
                                    modelPreviewImg.Image?.Dispose();
                                    modelPreviewImg.Image = image;
                                }));
                            }
                            else
                            {
                                modelPreviewImg.Image?.Dispose();
                                modelPreviewImg.Image = image;
                            }
                        }
                    }
                    else
                    {
                        // Thumbnail not available, clear the image
                        ClearModelPreviewImage();
                    }
                }
                // If the job hasn't changed, do nothing
            }
            else
            {
                // No current job, clear the image
                if (_lastJobFileName != null)
                {
                    _lastJobFileName = null;
                    ClearModelPreviewImage();
                }
            }
        }

        internal void ClearModelPreviewImage()
        {
            if (modelPreviewImg.InvokeRequired)
            {
                modelPreviewImg.Invoke(new Action(() =>
                {
                    modelPreviewImg.Image?.Dispose();
                    modelPreviewImg.Image = null;
                }));
            }
            else
            {
                modelPreviewImg.Image?.Dispose();
                modelPreviewImg.Image = null;
            }
        }

        private readonly SemaphoreSlim CmdButtonSemaphore = new SemaphoreSlim(1, 1);

        internal async Task CmdWait()
        {
            await CmdButtonSemaphore.WaitAsync();
        }

        internal void CmdRelease()
        {
            CmdButtonSemaphore.Release();
        }

        private async Task<bool> CmdBusy()
        {
            var isBusy = !await CmdButtonSemaphore.WaitAsync(0);
            if (isBusy) return true;
            CmdButtonSemaphore.Release(); // If acquired, release the semaphore
            return false;
        }
        
        
        
        // WebUI helper code

        public dynamic GetPrinterStatus()
        {
            if (InvokeRequired)
            {
                return Invoke(new Func<dynamic>(GetPrinterStatus));
            }

            return new
            {
                isPro = PrinterClient.IsPro,
                currentJob = currentJobLabel.Text,
                eta = etaLabel.Text,
                extruderTemp = extruderTempLabel.Text,
                bedTemp = bedTempLabel.Text,
                progress = progressLabel.Text,
                filamentUsed = totalFilamentLabel.Text,
                totalRunTime = totalRunTimeLabel.Text,
                printerStatus = printerStatusLabel.Text,
                layerInfo = layerLabel.Text,
                weight = weightLabel.Text,
                length = lengthLabel.Text,
                coolingFanSpeed = coolingFanLabel.Text,
                chamberFanSpeed = chamberFanLabel.Text,
                filtrationStatus = filterModeLabel.Text
            };
        }
        
        // todo don't forget about filament swap button click
        
        
        
        // Events 
        
        internal async void MainMenu_Shown(object sender, EventArgs e)
        {
            // load config
            Config = new Config().Load();
            
            _uiHelper = new UiHelper(this);
            if (Config.AlwaysOnTop) _uiHelper.SetOnTop();

            // init managers
            _connectionManager = new ConnectionManager(this);
            
            _statusTimerManager = new StatusTimerManager(this, _uiHelper);
            
            
            ButtonManager = new ButtonManager(this);
            MjpegStreamManager = new MjpegStreamManager(this);
            
            
            // only show console window if in debug mode
            if (Config.DebugMode) Program.AllocConsole();

            IsConnected = await Connect();
        }

        internal async Task<bool> Connect()
        {
            var connected = await _connectionManager.FindPrinterAndConnect();
            if (connected)
            {
                AppendLog($"Connected to {PrinterClient.PrinterName} @ {PrinterClient.IpAddress}");
                AppendLog($"Firmware version: {PrinterClient.FirmwareVersion}");

                CheckFeatures();
                
                if (Config.DiscordSync) InitWebhook(); // only check/enable the webhook if the user actually enabled it.
                StartTimers();
                if (Config.WebUi) StartWebUi();

                return true;
            }

            return false;
        }
        

        internal void MainMenu_Closed(object sender, FormClosedEventArgs e)
        {
            MjpegStreamManager.Stop();
        }

        private async void ledOnButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.LedOn();
        }

        private async void ledOffButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.LedOff();
        }

        private async void pauseJobButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.PauseJob();
        }

        private async void resumeJobButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.ResumeJob();
        }

        private async void stopJobButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.StopJob();
        }

        private async void swapFilamentButton_Click(object sender, EventArgs e)
        {
            // todo impl
        }

        private async void homeAxesButton_Click(object sender, EventArgs e)
        {
            if (!await CheckJobReady()) return;
            if (await CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            await CmdWait();
            AppendLog("Homing axes");
            var homed = await PrinterClient.Control.HomeAxes();
            AppendLog(homed ? "Homed." : "Error homing axes.");
            CmdRelease();
        }

        private async void uploadJobButton_Click(object sender, EventArgs e)
        {
            if (!await CheckJobReady()) return; // make sure the printer is ready for a new job
            if (!await ButtonManager.SelectAndUploadGCodeFile()) AppendLog("Uploading new job cancelled.");
        }

        private async void startRecentJobButton_Click(object sender, EventArgs e)
        {
            if (!await CheckJobReady()) return;
            await ButtonManager.SelectRecentJob();
        }

        private async void startLocalJobButton_Click(object sender, EventArgs e)
        {
            if (!await CheckJobReady()) return;
            await ButtonManager.SelectLocalJob();
        }

        private void sendCmdButton_Click(object sender, EventArgs e)
        {
            new SendCommandWindow(PrinterClient.TcpClient, this).ShowDialog();
        }

        private void toggleWebcamButton_Click(object sender, EventArgs e)
        {
            ButtonManager.TogglePreview();
        }

        private async void setBedTempButton_Click(object sender, EventArgs e)
        {
            if (await CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            var input = Interaction.InputBox("Bed temp (max 100)", "Set Bed Temperature", "0");
            if (int.TryParse(input, out var temp))
            {
                if (temp > 100) MessageBox.Show("Cannot set above 100C!");
                else
                {
                    await CmdWait();
                    if (await PrinterClient.TempControl.SetBedTemp(temp)) AppendLog($"Bed temp set to {temp}C");
                    else AppendLog("Unable to set bed temp!!");
                    CmdRelease();
                }
            }
            else
            {
                MessageBox.Show("Invalid input.", "Cancelled");
            }
        }

        private async void disableBedHeatButton_Click(object sender, EventArgs e)
        {
            if (await CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            await CmdWait();
            if (!await PrinterClient.TempControl.CancelBedTemp()) AppendLog("Unable to turn off bed heating!!");
            else AppendLog("Bed heating disabled.");
            CmdRelease();
        }

        private async void setExtruderTempButton_Click(object sender, EventArgs e)
        {
            if (await CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            var input = Interaction.InputBox("Extruder temp (max 280)", "Set Extruder Temperature", "0");
            if (int.TryParse(input, out var temp))
            {
                if (temp > 280) MessageBox.Show("Cannot set above 280C!");
                else
                {
                    await CmdWait();
                    if (await PrinterClient.TempControl.SetExtruderTemp(temp)) AppendLog($"Extruder temp set to {temp}C");
                    else AppendLog("Unable to set extruder temp!!");
                    CmdRelease();
                }
            }
            else
            {
                MessageBox.Show("Invalid input.", "Cancelled");
            }
        }

        private async void disableExtruderHeatButton_Click(object sender, EventArgs e)
        {
            if (await CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            await CmdWait();
            if (!await PrinterClient.TempControl.CancelExtruderTemp()) AppendLog("Unable to turn off extruder heat!!");
            else AppendLog("Extruder heating disabled.");
            CmdRelease();
        }

        private async void externalFiltrationButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.ExternalFilterOn();
        }

        private async void internalFiltrationButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.InternalFilterOn();
        }

        private async void disableFiltrationButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.FilteringOff();
        }

        private async void setCoolingFanButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.SetCoolingFanSpeed();
        }

        private async void setChamberFanButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.SetChamberFanSpeed();
        }

        private async void setSpeedOffsetButton_Click(object sender, EventArgs e)
        {
            // todo impl
        }

        private async void setZaxisOffsetButton_Click(object sender, EventArgs e)
        {
            // todo impl
        }

        private async void clearPlatformButton_Click(object sender, EventArgs e)
        {
            await ButtonManager.ClearPlatform();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ButtonManager.OpenSettings();
        }

        // todo disconnect button?
        
        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                MessageBox.Show("You're already connected to a printer!", "Already connected!");
                return;
            }
            IsConnected = await Connect();
        }
    }
}