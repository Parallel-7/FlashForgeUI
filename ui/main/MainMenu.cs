using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using FiveMApi.api;
using FlashForgeUI.manager;
using FlashForgeUI.program.util;
using FlashForgeUI.ui.main.dialog;
using FlashForgeUI.ui.main.manager;
using FlashForgeUI.ui.main.manager.camera;
using FlashForgeUI.ui.main.util;
using FlashForgeUI.webui;

namespace FlashForgeUI.ui.main
{
    public partial class MainMenu : Form
    {
        
        internal MJPEGStream MjpegStream;
        public FiveMClient PrinterClient;

        internal PrinterWebServer WebServer;
        internal WebhookHelper Webhook;
        internal Config Config;
        internal string LastJobName;
        
        internal ConnectionManager ConnectionManager;
        private StatusTimerManager _statusTimerManager;
        internal MjpegStreamManager MjpegStreamManager;
        internal ButtonManager ButtonManager;
        internal InteractionManager InteractionManager;
        internal UiHelper UiHelper;
        
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
                Config.DiscordSync = false;
                Config.Save();
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
            if (Config.DiscordSync)
            {
                timerSyncDiscord.Start();
                timerSyncDiscord_Tick(null, null); // kick start before first timer elapses
            }
        }

        private void StartWebUi()
        {
            WebServer = new PrinterWebServer(this, Config);
            WebServer.Start();
        }

        
        // Timer Events
        private async void timerSyncDiscord_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Ticking SyncDiscord");
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
            logBox.Invoke(new Action(() =>
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
            }));
        }
        
        internal async Task<bool> CheckJobReady()
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
        
        


        private readonly SemaphoreSlim CmdButtonSemaphore = new SemaphoreSlim(1, 1);

        internal async Task CmdWait()
        {
            await CmdButtonSemaphore.WaitAsync();
        }

        internal void CmdRelease()
        {
            CmdButtonSemaphore.Release();
        }

        internal async Task<bool> CmdBusy()
        {
            var isBusy = !await CmdButtonSemaphore.WaitAsync(0);
            if (isBusy) return true;
            CmdButtonSemaphore.Release(); // If acquired, release the semaphore
            return false;
        }
        
        // Events 
        
        internal async void MainMenu_Shown(object sender, EventArgs e)
        {
            Init();
            IsConnected = await Connect();
        }

        private void Init()
        {
            Config = new Config().Load(); // load config
            UiHelper = new UiHelper(this);
            
            if (Config.AlwaysOnTop) UiHelper.SetOnTop(); // apply always on top to main window
            if (Config.DebugMode) Program.AllocConsole(); // allocate console if in debug mode
            
            ButtonManager = new ButtonManager(this);
            MjpegStreamManager = new MjpegStreamManager(this);
            InteractionManager = new InteractionManager(this);
            
            ConnectionManager = new ConnectionManager(this);
            _statusTimerManager = new StatusTimerManager(this);
        }
        

        internal async Task<bool> Connect()
        {
            var connected = await ConnectionManager.FindPrinterAndConnect();
            if (connected)
            {
                AppendLog($"Connected to {PrinterClient.PrinterName} @ {PrinterClient.IpAddress}");
                AppendLog($"Firmware version: {PrinterClient.FirmwareVersion}");

                UiHelper.CheckFeatures();
                
                if (Config.DiscordSync) InitWebhook(); // init discord sync and/or web UI
                if (Config.WebUi) StartWebUi();

                if (PrinterClient.IsPro || Config.CustomCamera && !string.IsNullOrEmpty(Config.CustomCameraUrl)) ButtonManager.PreviewOn(); // start preview
                
                StartTimers();
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
            await InteractionManager.HandleHomeAxes();
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
            await InteractionManager.HandleSetBedTemp();
        }

        private async void disableBedHeatButton_Click(object sender, EventArgs e)
        {
            await InteractionManager.HandleCancelBedTemp();
        }

        private async void setExtruderTempButton_Click(object sender, EventArgs e)
        {
            await InteractionManager.HandleSetExtruderTemp();
        }

        private async void disableExtruderHeatButton_Click(object sender, EventArgs e)
        {
            await InteractionManager.HandleCancelExtruderTemp();
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
            currentJobLabel.Text = "Current Job: None";
            LastJobName = "cleared";
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