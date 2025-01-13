using System.ComponentModel;

namespace FlashForgeUI.ui.main
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainWindow = new ReaLTaiizor.Forms.NightForm();
            this.mainStatusLabel = new ReaLTaiizor.Controls.NightLabel();
            this.jobInfoLabel = new ReaLTaiizor.Controls.NightLabel();
            this.modelPreviewLabel = new ReaLTaiizor.Controls.NightLabel();
            this.nightPanel2 = new ReaLTaiizor.Controls.NightPanel();
            this.nightPanel3 = new ReaLTaiizor.Controls.NightPanel();
            this.setZaxisOffsetButton = new ReaLTaiizor.Controls.HopeButton();
            this.setSpeedOffsetButton = new ReaLTaiizor.Controls.HopeButton();
            this.zAxisOffsetLabel = new ReaLTaiizor.Controls.NightLabel();
            this.speedOffsetLabel = new ReaLTaiizor.Controls.NightLabel();
            this.filamentTypeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.nozzleSizeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.logBox = new ReaLTaiizor.Controls.ForeverListBox();
            this.filtrationPanel = new ReaLTaiizor.Controls.NightPanel();
            this.disableFiltrationButton = new ReaLTaiizor.Controls.HopeButton();
            this.internalFiltrationButton = new ReaLTaiizor.Controls.HopeButton();
            this.externalFiltrationButton = new ReaLTaiizor.Controls.HopeButton();
            this.tvocLabel = new ReaLTaiizor.Controls.NightLabel();
            this.filterModeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.fansPanel = new ReaLTaiizor.Controls.NightPanel();
            this.setChamberFanButton = new ReaLTaiizor.Controls.HopeButton();
            this.setCoolingFanButton = new ReaLTaiizor.Controls.HopeButton();
            this.chamberFanLabel = new ReaLTaiizor.Controls.NightLabel();
            this.coolingFanLabel = new ReaLTaiizor.Controls.NightLabel();
            this.tempsPanel = new ReaLTaiizor.Controls.NightPanel();
            this.disableExtruderHeatButton = new ReaLTaiizor.Controls.HopeButton();
            this.disableBedHeatButton = new ReaLTaiizor.Controls.HopeButton();
            this.setExtruderTempButton = new ReaLTaiizor.Controls.HopeButton();
            this.setBedTempButton = new ReaLTaiizor.Controls.HopeButton();
            this.extruderTempLabel = new ReaLTaiizor.Controls.NightLabel();
            this.bedTempLabel = new ReaLTaiizor.Controls.NightLabel();
            this.basicInfoPanel = new ReaLTaiizor.Controls.NightPanel();
            this.totalFilamentLabel = new ReaLTaiizor.Controls.NightLabel();
            this.totalRunTimeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.printerStatusLabel = new ReaLTaiizor.Controls.NightLabel();
            this.nightPanel1 = new ReaLTaiizor.Controls.NightPanel();
            this.lengthLabel = new ReaLTaiizor.Controls.NightLabel();
            this.weightLabel = new ReaLTaiizor.Controls.NightLabel();
            this.jobTimeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.etaLabel = new ReaLTaiizor.Controls.NightLabel();
            this.layerLabel = new ReaLTaiizor.Controls.NightLabel();
            this.modelPreviewPanel = new ReaLTaiizor.Controls.NightPanel();
            this.modelPreviewImg = new System.Windows.Forms.PictureBox();
            this.controlPanel = new ReaLTaiizor.Controls.NightPanel();
            this.clearPlatformButton = new ReaLTaiizor.Controls.HopeButton();
            this.sendCmdButton = new ReaLTaiizor.Controls.HopeButton();
            this.startLocalJobButton = new ReaLTaiizor.Controls.HopeButton();
            this.startRecentJobButton = new ReaLTaiizor.Controls.HopeButton();
            this.uploadJobButton = new ReaLTaiizor.Controls.HopeButton();
            this.homeAxesButton = new ReaLTaiizor.Controls.HopeButton();
            this.swapFilamentButton = new ReaLTaiizor.Controls.HopeButton();
            this.stopJobButton = new ReaLTaiizor.Controls.HopeButton();
            this.resumeJobButton = new ReaLTaiizor.Controls.HopeButton();
            this.pauseJobButton = new ReaLTaiizor.Controls.HopeButton();
            this.ledOffButton = new ReaLTaiizor.Controls.HopeButton();
            this.ledOnButton = new ReaLTaiizor.Controls.HopeButton();
            this.webcamPanel = new ReaLTaiizor.Controls.NightPanel();
            this.toggleWebcamButton = new ReaLTaiizor.Controls.HopeButton();
            this.poisonProgressBar1 = new ReaLTaiizor.Controls.PoisonProgressBar();
            this.progressLabel = new ReaLTaiizor.Controls.NightLabel();
            this.currentJobLabel = new ReaLTaiizor.Controls.NightLabel();
            this.webcamPictureBox = new System.Windows.Forms.PictureBox();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.timerSyncInfo = new System.Windows.Forms.Timer(this.components);
            this.timerSyncDiscord = new System.Windows.Forms.Timer(this.components);
            this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.mainWindow.SuspendLayout();
            this.nightPanel2.SuspendLayout();
            this.nightPanel3.SuspendLayout();
            this.filtrationPanel.SuspendLayout();
            this.fansPanel.SuspendLayout();
            this.tempsPanel.SuspendLayout();
            this.basicInfoPanel.SuspendLayout();
            this.nightPanel1.SuspendLayout();
            this.modelPreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelPreviewImg)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.webcamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainWindow
            // 
            this.mainWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.mainWindow.Controls.Add(this.mainStatusLabel);
            this.mainWindow.Controls.Add(this.jobInfoLabel);
            this.mainWindow.Controls.Add(this.modelPreviewLabel);
            this.mainWindow.Controls.Add(this.nightPanel2);
            this.mainWindow.Controls.Add(this.nightPanel1);
            this.mainWindow.Controls.Add(this.modelPreviewPanel);
            this.mainWindow.Controls.Add(this.controlPanel);
            this.mainWindow.Controls.Add(this.webcamPanel);
            this.mainWindow.Controls.Add(this.nightControlBox1);
            this.mainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindow.DrawIcon = false;
            this.mainWindow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mainWindow.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.mainWindow.Location = new System.Drawing.Point(0, 0);
            this.mainWindow.MinimumSize = new System.Drawing.Size(100, 42);
            this.mainWindow.Name = "mainWindow";
            this.mainWindow.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.mainWindow.Size = new System.Drawing.Size(816, 845);
            this.mainWindow.TabIndex = 0;
            this.mainWindow.Text = "FlashForge UI 1.0";
            this.mainWindow.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            this.mainWindow.TitleBarTextColor = System.Drawing.Color.Gainsboro;
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusLabel.ForeColor = System.Drawing.Color.Silver;
            this.mainStatusLabel.Location = new System.Drawing.Point(22, 466);
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(94, 19);
            this.mainStatusLabel.TabIndex = 7;
            this.mainStatusLabel.Text = "Status";
            // 
            // jobInfoLabel
            // 
            this.jobInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.jobInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobInfoLabel.ForeColor = System.Drawing.Color.Silver;
            this.jobInfoLabel.Location = new System.Drawing.Point(660, 284);
            this.jobInfoLabel.Name = "jobInfoLabel";
            this.jobInfoLabel.Size = new System.Drawing.Size(94, 19);
            this.jobInfoLabel.TabIndex = 6;
            this.jobInfoLabel.Text = "Job Info";
            // 
            // modelPreviewLabel
            // 
            this.modelPreviewLabel.BackColor = System.Drawing.Color.Transparent;
            this.modelPreviewLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelPreviewLabel.ForeColor = System.Drawing.Color.Silver;
            this.modelPreviewLabel.Location = new System.Drawing.Point(481, 284);
            this.modelPreviewLabel.Name = "modelPreviewLabel";
            this.modelPreviewLabel.Size = new System.Drawing.Size(94, 19);
            this.modelPreviewLabel.TabIndex = 3;
            this.modelPreviewLabel.Text = "Model Preview";
            // 
            // nightPanel2
            // 
            this.nightPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nightPanel2.Controls.Add(this.nightPanel3);
            this.nightPanel2.Controls.Add(this.logBox);
            this.nightPanel2.Controls.Add(this.filtrationPanel);
            this.nightPanel2.Controls.Add(this.fansPanel);
            this.nightPanel2.Controls.Add(this.tempsPanel);
            this.nightPanel2.Controls.Add(this.basicInfoPanel);
            this.nightPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightPanel2.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel2.Location = new System.Drawing.Point(12, 488);
            this.nightPanel2.Name = "nightPanel2";
            this.nightPanel2.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel2.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.nightPanel2.Size = new System.Drawing.Size(792, 345);
            this.nightPanel2.TabIndex = 5;
            // 
            // nightPanel3
            // 
            this.nightPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nightPanel3.Controls.Add(this.setZaxisOffsetButton);
            this.nightPanel3.Controls.Add(this.setSpeedOffsetButton);
            this.nightPanel3.Controls.Add(this.zAxisOffsetLabel);
            this.nightPanel3.Controls.Add(this.speedOffsetLabel);
            this.nightPanel3.Controls.Add(this.filamentTypeLabel);
            this.nightPanel3.Controls.Add(this.nozzleSizeLabel);
            this.nightPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightPanel3.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel3.Location = new System.Drawing.Point(640, 15);
            this.nightPanel3.Name = "nightPanel3";
            this.nightPanel3.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel3.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.nightPanel3.Size = new System.Drawing.Size(136, 179);
            this.nightPanel3.TabIndex = 5;
            // 
            // setZaxisOffsetButton
            // 
            this.setZaxisOffsetButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setZaxisOffsetButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setZaxisOffsetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setZaxisOffsetButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setZaxisOffsetButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setZaxisOffsetButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setZaxisOffsetButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setZaxisOffsetButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setZaxisOffsetButton.Location = new System.Drawing.Point(8, 142);
            this.setZaxisOffsetButton.Name = "setZaxisOffsetButton";
            this.setZaxisOffsetButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setZaxisOffsetButton.Size = new System.Drawing.Size(106, 24);
            this.setZaxisOffsetButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setZaxisOffsetButton.TabIndex = 15;
            this.setZaxisOffsetButton.Text = "Set";
            this.setZaxisOffsetButton.TextColor = System.Drawing.Color.White;
            this.setZaxisOffsetButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.setZaxisOffsetButton.Click += new System.EventHandler(this.setZaxisOffsetButton_Click);
            // 
            // setSpeedOffsetButton
            // 
            this.setSpeedOffsetButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setSpeedOffsetButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setSpeedOffsetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setSpeedOffsetButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setSpeedOffsetButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setSpeedOffsetButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setSpeedOffsetButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setSpeedOffsetButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setSpeedOffsetButton.Location = new System.Drawing.Point(8, 89);
            this.setSpeedOffsetButton.Name = "setSpeedOffsetButton";
            this.setSpeedOffsetButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setSpeedOffsetButton.Size = new System.Drawing.Size(106, 24);
            this.setSpeedOffsetButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setSpeedOffsetButton.TabIndex = 8;
            this.setSpeedOffsetButton.Text = "Set";
            this.setSpeedOffsetButton.TextColor = System.Drawing.Color.White;
            this.setSpeedOffsetButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.setSpeedOffsetButton.Click += new System.EventHandler(this.setSpeedOffsetButton_Click);
            // 
            // zAxisOffsetLabel
            // 
            this.zAxisOffsetLabel.BackColor = System.Drawing.Color.Transparent;
            this.zAxisOffsetLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zAxisOffsetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.zAxisOffsetLabel.Location = new System.Drawing.Point(3, 116);
            this.zAxisOffsetLabel.Name = "zAxisOffsetLabel";
            this.zAxisOffsetLabel.Size = new System.Drawing.Size(130, 23);
            this.zAxisOffsetLabel.TabIndex = 14;
            this.zAxisOffsetLabel.Text = "Z-Axis Offset: 100";
            this.zAxisOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // speedOffsetLabel
            // 
            this.speedOffsetLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedOffsetLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedOffsetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.speedOffsetLabel.Location = new System.Drawing.Point(3, 63);
            this.speedOffsetLabel.Name = "speedOffsetLabel";
            this.speedOffsetLabel.Size = new System.Drawing.Size(130, 23);
            this.speedOffsetLabel.TabIndex = 13;
            this.speedOffsetLabel.Text = "Speed Offset: 100";
            this.speedOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filamentTypeLabel
            // 
            this.filamentTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.filamentTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filamentTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.filamentTypeLabel.Location = new System.Drawing.Point(3, 33);
            this.filamentTypeLabel.Name = "filamentTypeLabel";
            this.filamentTypeLabel.Size = new System.Drawing.Size(130, 23);
            this.filamentTypeLabel.TabIndex = 12;
            this.filamentTypeLabel.Text = "Filament: HS PLA";
            this.filamentTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nozzleSizeLabel
            // 
            this.nozzleSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.nozzleSizeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nozzleSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nozzleSizeLabel.Location = new System.Drawing.Point(3, 6);
            this.nozzleSizeLabel.Name = "nozzleSizeLabel";
            this.nozzleSizeLabel.Size = new System.Drawing.Size(130, 23);
            this.nozzleSizeLabel.TabIndex = 11;
            this.nozzleSizeLabel.Text = "Nozzle: 0,4mm";
            this.nozzleSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.logBox.Items = new string[0];
            this.logBox.Location = new System.Drawing.Point(12, 201);
            this.logBox.Name = "logBox";
            this.logBox.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logBox.SelectedIndex = 0;
            this.logBox.SelectedItem = "";
            this.logBox.Size = new System.Drawing.Size(765, 139);
            this.logBox.TabIndex = 4;
            this.logBox.Text = "foreverListBox1";
            // 
            // filtrationPanel
            // 
            this.filtrationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filtrationPanel.Controls.Add(this.disableFiltrationButton);
            this.filtrationPanel.Controls.Add(this.internalFiltrationButton);
            this.filtrationPanel.Controls.Add(this.externalFiltrationButton);
            this.filtrationPanel.Controls.Add(this.tvocLabel);
            this.filtrationPanel.Controls.Add(this.filterModeLabel);
            this.filtrationPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.filtrationPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filtrationPanel.Location = new System.Drawing.Point(457, 13);
            this.filtrationPanel.Name = "filtrationPanel";
            this.filtrationPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filtrationPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.filtrationPanel.Size = new System.Drawing.Size(177, 182);
            this.filtrationPanel.TabIndex = 3;
            // 
            // disableFiltrationButton
            // 
            this.disableFiltrationButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.disableFiltrationButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.disableFiltrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disableFiltrationButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.disableFiltrationButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.disableFiltrationButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.disableFiltrationButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.disableFiltrationButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.disableFiltrationButton.Location = new System.Drawing.Point(14, 126);
            this.disableFiltrationButton.Name = "disableFiltrationButton";
            this.disableFiltrationButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.disableFiltrationButton.Size = new System.Drawing.Size(137, 27);
            this.disableFiltrationButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.disableFiltrationButton.TabIndex = 7;
            this.disableFiltrationButton.Text = "No Filtration";
            this.disableFiltrationButton.TextColor = System.Drawing.Color.White;
            this.disableFiltrationButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.disableFiltrationButton.Click += new System.EventHandler(this.disableFiltrationButton_Click);
            // 
            // internalFiltrationButton
            // 
            this.internalFiltrationButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.internalFiltrationButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.internalFiltrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.internalFiltrationButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.internalFiltrationButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.internalFiltrationButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.internalFiltrationButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.internalFiltrationButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.internalFiltrationButton.Location = new System.Drawing.Point(14, 93);
            this.internalFiltrationButton.Name = "internalFiltrationButton";
            this.internalFiltrationButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.internalFiltrationButton.Size = new System.Drawing.Size(137, 27);
            this.internalFiltrationButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.internalFiltrationButton.TabIndex = 6;
            this.internalFiltrationButton.Text = "Internal Filtration";
            this.internalFiltrationButton.TextColor = System.Drawing.Color.White;
            this.internalFiltrationButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.internalFiltrationButton.Click += new System.EventHandler(this.internalFiltrationButton_Click);
            // 
            // externalFiltrationButton
            // 
            this.externalFiltrationButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.externalFiltrationButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.externalFiltrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.externalFiltrationButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.externalFiltrationButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.externalFiltrationButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.externalFiltrationButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.externalFiltrationButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.externalFiltrationButton.Location = new System.Drawing.Point(14, 60);
            this.externalFiltrationButton.Name = "externalFiltrationButton";
            this.externalFiltrationButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.externalFiltrationButton.Size = new System.Drawing.Size(137, 27);
            this.externalFiltrationButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.externalFiltrationButton.TabIndex = 5;
            this.externalFiltrationButton.Text = "External Filtration";
            this.externalFiltrationButton.TextColor = System.Drawing.Color.White;
            this.externalFiltrationButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.externalFiltrationButton.Click += new System.EventHandler(this.externalFiltrationButton_Click);
            // 
            // tvocLabel
            // 
            this.tvocLabel.BackColor = System.Drawing.Color.Transparent;
            this.tvocLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvocLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tvocLabel.Location = new System.Drawing.Point(15, 33);
            this.tvocLabel.Name = "tvocLabel";
            this.tvocLabel.Size = new System.Drawing.Size(136, 23);
            this.tvocLabel.TabIndex = 4;
            this.tvocLabel.Text = "TVOC Level: --";
            this.tvocLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // filterModeLabel
            // 
            this.filterModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.filterModeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.filterModeLabel.Location = new System.Drawing.Point(15, 10);
            this.filterModeLabel.Name = "filterModeLabel";
            this.filterModeLabel.Size = new System.Drawing.Size(136, 23);
            this.filterModeLabel.TabIndex = 3;
            this.filterModeLabel.Text = "Filtration: None";
            this.filterModeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fansPanel
            // 
            this.fansPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fansPanel.Controls.Add(this.setChamberFanButton);
            this.fansPanel.Controls.Add(this.setCoolingFanButton);
            this.fansPanel.Controls.Add(this.chamberFanLabel);
            this.fansPanel.Controls.Add(this.coolingFanLabel);
            this.fansPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.fansPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fansPanel.Location = new System.Drawing.Point(195, 107);
            this.fansPanel.Name = "fansPanel";
            this.fansPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fansPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.fansPanel.Size = new System.Drawing.Size(252, 88);
            this.fansPanel.TabIndex = 2;
            // 
            // setChamberFanButton
            // 
            this.setChamberFanButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setChamberFanButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setChamberFanButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setChamberFanButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setChamberFanButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setChamberFanButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setChamberFanButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setChamberFanButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setChamberFanButton.Location = new System.Drawing.Point(158, 50);
            this.setChamberFanButton.Name = "setChamberFanButton";
            this.setChamberFanButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setChamberFanButton.Size = new System.Drawing.Size(54, 24);
            this.setChamberFanButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setChamberFanButton.TabIndex = 8;
            this.setChamberFanButton.Text = "Set";
            this.setChamberFanButton.TextColor = System.Drawing.Color.White;
            this.setChamberFanButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.setChamberFanButton.Click += new System.EventHandler(this.setChamberFanButton_Click);
            // 
            // setCoolingFanButton
            // 
            this.setCoolingFanButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setCoolingFanButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setCoolingFanButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setCoolingFanButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setCoolingFanButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setCoolingFanButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setCoolingFanButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setCoolingFanButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setCoolingFanButton.Location = new System.Drawing.Point(158, 9);
            this.setCoolingFanButton.Name = "setCoolingFanButton";
            this.setCoolingFanButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setCoolingFanButton.Size = new System.Drawing.Size(54, 24);
            this.setCoolingFanButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setCoolingFanButton.TabIndex = 7;
            this.setCoolingFanButton.Text = "Set";
            this.setCoolingFanButton.TextColor = System.Drawing.Color.White;
            this.setCoolingFanButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.setCoolingFanButton.Click += new System.EventHandler(this.setCoolingFanButton_Click);
            // 
            // chamberFanLabel
            // 
            this.chamberFanLabel.BackColor = System.Drawing.Color.Transparent;
            this.chamberFanLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chamberFanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chamberFanLabel.Location = new System.Drawing.Point(3, 54);
            this.chamberFanLabel.Name = "chamberFanLabel";
            this.chamberFanLabel.Size = new System.Drawing.Size(117, 23);
            this.chamberFanLabel.TabIndex = 6;
            this.chamberFanLabel.Text = "Chamber Fan: 100";
            // 
            // coolingFanLabel
            // 
            this.coolingFanLabel.BackColor = System.Drawing.Color.Transparent;
            this.coolingFanLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coolingFanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.coolingFanLabel.Location = new System.Drawing.Point(3, 12);
            this.coolingFanLabel.Name = "coolingFanLabel";
            this.coolingFanLabel.Size = new System.Drawing.Size(117, 23);
            this.coolingFanLabel.TabIndex = 5;
            this.coolingFanLabel.Text = "Cooling Fan: 100";
            // 
            // tempsPanel
            // 
            this.tempsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tempsPanel.Controls.Add(this.disableExtruderHeatButton);
            this.tempsPanel.Controls.Add(this.disableBedHeatButton);
            this.tempsPanel.Controls.Add(this.setExtruderTempButton);
            this.tempsPanel.Controls.Add(this.setBedTempButton);
            this.tempsPanel.Controls.Add(this.extruderTempLabel);
            this.tempsPanel.Controls.Add(this.bedTempLabel);
            this.tempsPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tempsPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tempsPanel.Location = new System.Drawing.Point(195, 13);
            this.tempsPanel.Name = "tempsPanel";
            this.tempsPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tempsPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.tempsPanel.Size = new System.Drawing.Size(252, 88);
            this.tempsPanel.TabIndex = 1;
            // 
            // disableExtruderHeatButton
            // 
            this.disableExtruderHeatButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.disableExtruderHeatButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.disableExtruderHeatButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disableExtruderHeatButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.disableExtruderHeatButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.disableExtruderHeatButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.disableExtruderHeatButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.disableExtruderHeatButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.disableExtruderHeatButton.Location = new System.Drawing.Point(203, 46);
            this.disableExtruderHeatButton.Name = "disableExtruderHeatButton";
            this.disableExtruderHeatButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.disableExtruderHeatButton.Size = new System.Drawing.Size(38, 24);
            this.disableExtruderHeatButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.disableExtruderHeatButton.TabIndex = 7;
            this.disableExtruderHeatButton.Text = "Off";
            this.disableExtruderHeatButton.TextColor = System.Drawing.Color.White;
            this.disableExtruderHeatButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // disableBedHeatButton
            // 
            this.disableBedHeatButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.disableBedHeatButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.disableBedHeatButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disableBedHeatButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.disableBedHeatButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.disableBedHeatButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.disableBedHeatButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.disableBedHeatButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.disableBedHeatButton.Location = new System.Drawing.Point(203, 7);
            this.disableBedHeatButton.Name = "disableBedHeatButton";
            this.disableBedHeatButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.disableBedHeatButton.Size = new System.Drawing.Size(38, 24);
            this.disableBedHeatButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.disableBedHeatButton.TabIndex = 6;
            this.disableBedHeatButton.Text = "Off";
            this.disableBedHeatButton.TextColor = System.Drawing.Color.White;
            this.disableBedHeatButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.disableBedHeatButton.Click += new System.EventHandler(this.disableBedHeatButton_Click);
            // 
            // setExtruderTempButton
            // 
            this.setExtruderTempButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setExtruderTempButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setExtruderTempButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setExtruderTempButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setExtruderTempButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setExtruderTempButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setExtruderTempButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setExtruderTempButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setExtruderTempButton.Location = new System.Drawing.Point(159, 46);
            this.setExtruderTempButton.Name = "setExtruderTempButton";
            this.setExtruderTempButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setExtruderTempButton.Size = new System.Drawing.Size(38, 24);
            this.setExtruderTempButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setExtruderTempButton.TabIndex = 6;
            this.setExtruderTempButton.Text = "Set";
            this.setExtruderTempButton.TextColor = System.Drawing.Color.White;
            this.setExtruderTempButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.setExtruderTempButton.Click += new System.EventHandler(this.setExtruderTempButton_Click);
            // 
            // setBedTempButton
            // 
            this.setBedTempButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setBedTempButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setBedTempButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setBedTempButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setBedTempButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setBedTempButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setBedTempButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setBedTempButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setBedTempButton.Location = new System.Drawing.Point(158, 6);
            this.setBedTempButton.Name = "setBedTempButton";
            this.setBedTempButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setBedTempButton.Size = new System.Drawing.Size(38, 24);
            this.setBedTempButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setBedTempButton.TabIndex = 5;
            this.setBedTempButton.Text = "Set";
            this.setBedTempButton.TextColor = System.Drawing.Color.White;
            this.setBedTempButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.setBedTempButton.Click += new System.EventHandler(this.setBedTempButton_Click);
            // 
            // extruderTempLabel
            // 
            this.extruderTempLabel.BackColor = System.Drawing.Color.Transparent;
            this.extruderTempLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extruderTempLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.extruderTempLabel.Location = new System.Drawing.Point(3, 47);
            this.extruderTempLabel.Name = "extruderTempLabel";
            this.extruderTempLabel.Size = new System.Drawing.Size(150, 23);
            this.extruderTempLabel.TabIndex = 5;
            this.extruderTempLabel.Text = "Extruder: 123.C/456.C";
            // 
            // bedTempLabel
            // 
            this.bedTempLabel.BackColor = System.Drawing.Color.Transparent;
            this.bedTempLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedTempLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bedTempLabel.Location = new System.Drawing.Point(3, 11);
            this.bedTempLabel.Name = "bedTempLabel";
            this.bedTempLabel.Size = new System.Drawing.Size(149, 23);
            this.bedTempLabel.TabIndex = 4;
            this.bedTempLabel.Text = "Bed: 123/456";
            // 
            // basicInfoPanel
            // 
            this.basicInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.basicInfoPanel.Controls.Add(this.totalFilamentLabel);
            this.basicInfoPanel.Controls.Add(this.totalRunTimeLabel);
            this.basicInfoPanel.Controls.Add(this.printerStatusLabel);
            this.basicInfoPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.basicInfoPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.basicInfoPanel.Location = new System.Drawing.Point(12, 13);
            this.basicInfoPanel.Name = "basicInfoPanel";
            this.basicInfoPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.basicInfoPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.basicInfoPanel.Size = new System.Drawing.Size(177, 182);
            this.basicInfoPanel.TabIndex = 0;
            // 
            // totalFilamentLabel
            // 
            this.totalFilamentLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalFilamentLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalFilamentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.totalFilamentLabel.Location = new System.Drawing.Point(3, 57);
            this.totalFilamentLabel.Name = "totalFilamentLabel";
            this.totalFilamentLabel.Size = new System.Drawing.Size(169, 23);
            this.totalFilamentLabel.TabIndex = 12;
            this.totalFilamentLabel.Text = "Filament Used: 123.456m";
            // 
            // totalRunTimeLabel
            // 
            this.totalRunTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalRunTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRunTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.totalRunTimeLabel.Location = new System.Drawing.Point(3, 34);
            this.totalRunTimeLabel.Name = "totalRunTimeLabel";
            this.totalRunTimeLabel.Size = new System.Drawing.Size(169, 23);
            this.totalRunTimeLabel.TabIndex = 11;
            this.totalRunTimeLabel.Text = "Run Time: 420h69m";
            // 
            // printerStatusLabel
            // 
            this.printerStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.printerStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.printerStatusLabel.Location = new System.Drawing.Point(3, 10);
            this.printerStatusLabel.Name = "printerStatusLabel";
            this.printerStatusLabel.Size = new System.Drawing.Size(141, 23);
            this.printerStatusLabel.TabIndex = 11;
            this.printerStatusLabel.Text = "Printer: Printing";
            // 
            // nightPanel1
            // 
            this.nightPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nightPanel1.Controls.Add(this.lengthLabel);
            this.nightPanel1.Controls.Add(this.weightLabel);
            this.nightPanel1.Controls.Add(this.jobTimeLabel);
            this.nightPanel1.Controls.Add(this.etaLabel);
            this.nightPanel1.Controls.Add(this.layerLabel);
            this.nightPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightPanel1.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel1.Location = new System.Drawing.Point(657, 303);
            this.nightPanel1.Name = "nightPanel1";
            this.nightPanel1.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel1.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.nightPanel1.Size = new System.Drawing.Size(147, 159);
            this.nightPanel1.TabIndex = 4;
            // 
            // lengthLabel
            // 
            this.lengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.lengthLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lengthLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lengthLabel.Location = new System.Drawing.Point(3, 111);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(141, 23);
            this.lengthLabel.TabIndex = 10;
            this.lengthLabel.Text = "Length: --";
            // 
            // weightLabel
            // 
            this.weightLabel.BackColor = System.Drawing.Color.Transparent;
            this.weightLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.weightLabel.Location = new System.Drawing.Point(3, 88);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(141, 23);
            this.weightLabel.TabIndex = 9;
            this.weightLabel.Text = "Weight: --";
            // 
            // jobTimeLabel
            // 
            this.jobTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.jobTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.jobTimeLabel.Location = new System.Drawing.Point(3, 65);
            this.jobTimeLabel.Name = "jobTimeLabel";
            this.jobTimeLabel.Size = new System.Drawing.Size(141, 23);
            this.jobTimeLabel.TabIndex = 8;
            this.jobTimeLabel.Text = "Job Time: --:--:--";
            // 
            // etaLabel
            // 
            this.etaLabel.BackColor = System.Drawing.Color.Transparent;
            this.etaLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.etaLabel.Location = new System.Drawing.Point(3, 42);
            this.etaLabel.Name = "etaLabel";
            this.etaLabel.Size = new System.Drawing.Size(141, 23);
            this.etaLabel.TabIndex = 4;
            this.etaLabel.Text = "ETA: --:--";
            // 
            // layerLabel
            // 
            this.layerLabel.BackColor = System.Drawing.Color.Transparent;
            this.layerLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.layerLabel.Location = new System.Drawing.Point(3, 19);
            this.layerLabel.Name = "layerLabel";
            this.layerLabel.Size = new System.Drawing.Size(141, 23);
            this.layerLabel.TabIndex = 3;
            this.layerLabel.Text = "Layer: --";
            // 
            // modelPreviewPanel
            // 
            this.modelPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelPreviewPanel.Controls.Add(this.modelPreviewImg);
            this.modelPreviewPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.modelPreviewPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modelPreviewPanel.Location = new System.Drawing.Point(481, 303);
            this.modelPreviewPanel.Name = "modelPreviewPanel";
            this.modelPreviewPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modelPreviewPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.modelPreviewPanel.Size = new System.Drawing.Size(170, 159);
            this.modelPreviewPanel.TabIndex = 3;
            // 
            // modelPreviewImg
            // 
            this.modelPreviewImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelPreviewImg.Location = new System.Drawing.Point(3, 3);
            this.modelPreviewImg.Name = "modelPreviewImg";
            this.modelPreviewImg.Size = new System.Drawing.Size(162, 151);
            this.modelPreviewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.modelPreviewImg.TabIndex = 0;
            this.modelPreviewImg.TabStop = false;
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.clearPlatformButton);
            this.controlPanel.Controls.Add(this.sendCmdButton);
            this.controlPanel.Controls.Add(this.startLocalJobButton);
            this.controlPanel.Controls.Add(this.startRecentJobButton);
            this.controlPanel.Controls.Add(this.uploadJobButton);
            this.controlPanel.Controls.Add(this.homeAxesButton);
            this.controlPanel.Controls.Add(this.swapFilamentButton);
            this.controlPanel.Controls.Add(this.stopJobButton);
            this.controlPanel.Controls.Add(this.resumeJobButton);
            this.controlPanel.Controls.Add(this.pauseJobButton);
            this.controlPanel.Controls.Add(this.ledOffButton);
            this.controlPanel.Controls.Add(this.ledOnButton);
            this.controlPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.controlPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlPanel.Location = new System.Drawing.Point(481, 37);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.controlPanel.Size = new System.Drawing.Size(323, 245);
            this.controlPanel.TabIndex = 2;
            // 
            // clearPlatformButton
            // 
            this.clearPlatformButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.clearPlatformButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.clearPlatformButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearPlatformButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.clearPlatformButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.clearPlatformButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearPlatformButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.clearPlatformButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.clearPlatformButton.Location = new System.Drawing.Point(200, 8);
            this.clearPlatformButton.Name = "clearPlatformButton";
            this.clearPlatformButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.clearPlatformButton.Size = new System.Drawing.Size(108, 32);
            this.clearPlatformButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.clearPlatformButton.TabIndex = 14;
            this.clearPlatformButton.Text = "Clear Platform";
            this.clearPlatformButton.TextColor = System.Drawing.Color.White;
            this.clearPlatformButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.clearPlatformButton.Click += new System.EventHandler(this.clearPlatformButton_Click);
            // 
            // sendCmdButton
            // 
            this.sendCmdButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.sendCmdButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.sendCmdButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendCmdButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.sendCmdButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendCmdButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCmdButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.sendCmdButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.sendCmdButton.Location = new System.Drawing.Point(200, 198);
            this.sendCmdButton.Name = "sendCmdButton";
            this.sendCmdButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.sendCmdButton.Size = new System.Drawing.Size(108, 32);
            this.sendCmdButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.sendCmdButton.TabIndex = 13;
            this.sendCmdButton.Text = "Send Cmds";
            this.sendCmdButton.TextColor = System.Drawing.Color.White;
            this.sendCmdButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.sendCmdButton.Click += new System.EventHandler(this.sendCmdButton_Click);
            // 
            // startLocalJobButton
            // 
            this.startLocalJobButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.startLocalJobButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.startLocalJobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startLocalJobButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.startLocalJobButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startLocalJobButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startLocalJobButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.startLocalJobButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.startLocalJobButton.Location = new System.Drawing.Point(200, 160);
            this.startLocalJobButton.Name = "startLocalJobButton";
            this.startLocalJobButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.startLocalJobButton.Size = new System.Drawing.Size(108, 32);
            this.startLocalJobButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.startLocalJobButton.TabIndex = 12;
            this.startLocalJobButton.Text = "Start Local";
            this.startLocalJobButton.TextColor = System.Drawing.Color.White;
            this.startLocalJobButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.startLocalJobButton.Click += new System.EventHandler(this.startLocalJobButton_Click);
            // 
            // startRecentJobButton
            // 
            this.startRecentJobButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.startRecentJobButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.startRecentJobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startRecentJobButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.startRecentJobButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startRecentJobButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startRecentJobButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.startRecentJobButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.startRecentJobButton.Location = new System.Drawing.Point(200, 122);
            this.startRecentJobButton.Name = "startRecentJobButton";
            this.startRecentJobButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.startRecentJobButton.Size = new System.Drawing.Size(108, 32);
            this.startRecentJobButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.startRecentJobButton.TabIndex = 11;
            this.startRecentJobButton.Text = "Start Recent";
            this.startRecentJobButton.TextColor = System.Drawing.Color.White;
            this.startRecentJobButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.startRecentJobButton.Click += new System.EventHandler(this.startRecentJobButton_Click);
            // 
            // uploadJobButton
            // 
            this.uploadJobButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.uploadJobButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.uploadJobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadJobButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.uploadJobButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uploadJobButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.uploadJobButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.uploadJobButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.uploadJobButton.Location = new System.Drawing.Point(200, 84);
            this.uploadJobButton.Name = "uploadJobButton";
            this.uploadJobButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.uploadJobButton.Size = new System.Drawing.Size(108, 32);
            this.uploadJobButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.uploadJobButton.TabIndex = 10;
            this.uploadJobButton.Text = "Upload Job";
            this.uploadJobButton.TextColor = System.Drawing.Color.White;
            this.uploadJobButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.uploadJobButton.Click += new System.EventHandler(this.uploadJobButton_Click);
            // 
            // homeAxesButton
            // 
            this.homeAxesButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.homeAxesButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.homeAxesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeAxesButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.homeAxesButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.homeAxesButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.homeAxesButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.homeAxesButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.homeAxesButton.Location = new System.Drawing.Point(200, 46);
            this.homeAxesButton.Name = "homeAxesButton";
            this.homeAxesButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.homeAxesButton.Size = new System.Drawing.Size(108, 32);
            this.homeAxesButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.homeAxesButton.TabIndex = 9;
            this.homeAxesButton.Text = "Home Axes";
            this.homeAxesButton.TextColor = System.Drawing.Color.White;
            this.homeAxesButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.homeAxesButton.Click += new System.EventHandler(this.homeAxesButton_Click);
            // 
            // swapFilamentButton
            // 
            this.swapFilamentButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.swapFilamentButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.swapFilamentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swapFilamentButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.swapFilamentButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.swapFilamentButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swapFilamentButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.swapFilamentButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.swapFilamentButton.Location = new System.Drawing.Point(13, 198);
            this.swapFilamentButton.Name = "swapFilamentButton";
            this.swapFilamentButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.swapFilamentButton.Size = new System.Drawing.Size(108, 32);
            this.swapFilamentButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.swapFilamentButton.TabIndex = 8;
            this.swapFilamentButton.Text = "Swap Filament";
            this.swapFilamentButton.TextColor = System.Drawing.Color.White;
            this.swapFilamentButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.swapFilamentButton.Click += new System.EventHandler(this.swapFilamentButton_Click);
            // 
            // stopJobButton
            // 
            this.stopJobButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.stopJobButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.stopJobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopJobButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.stopJobButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stopJobButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.stopJobButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.stopJobButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.stopJobButton.Location = new System.Drawing.Point(13, 160);
            this.stopJobButton.Name = "stopJobButton";
            this.stopJobButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.stopJobButton.Size = new System.Drawing.Size(108, 32);
            this.stopJobButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.stopJobButton.TabIndex = 7;
            this.stopJobButton.Text = "Stop";
            this.stopJobButton.TextColor = System.Drawing.Color.White;
            this.stopJobButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.stopJobButton.Click += new System.EventHandler(this.stopJobButton_Click);
            // 
            // resumeJobButton
            // 
            this.resumeJobButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.resumeJobButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.resumeJobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resumeJobButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.resumeJobButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resumeJobButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.resumeJobButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.resumeJobButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.resumeJobButton.Location = new System.Drawing.Point(13, 122);
            this.resumeJobButton.Name = "resumeJobButton";
            this.resumeJobButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.resumeJobButton.Size = new System.Drawing.Size(108, 32);
            this.resumeJobButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.resumeJobButton.TabIndex = 6;
            this.resumeJobButton.Text = "Resume";
            this.resumeJobButton.TextColor = System.Drawing.Color.White;
            this.resumeJobButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.resumeJobButton.Click += new System.EventHandler(this.resumeJobButton_Click);
            // 
            // pauseJobButton
            // 
            this.pauseJobButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.pauseJobButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.pauseJobButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pauseJobButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.pauseJobButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pauseJobButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pauseJobButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.pauseJobButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.pauseJobButton.Location = new System.Drawing.Point(13, 84);
            this.pauseJobButton.Name = "pauseJobButton";
            this.pauseJobButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.pauseJobButton.Size = new System.Drawing.Size(108, 32);
            this.pauseJobButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.pauseJobButton.TabIndex = 5;
            this.pauseJobButton.Text = "Pause";
            this.pauseJobButton.TextColor = System.Drawing.Color.White;
            this.pauseJobButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.pauseJobButton.Click += new System.EventHandler(this.pauseJobButton_Click);
            // 
            // ledOffButton
            // 
            this.ledOffButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.ledOffButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.ledOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ledOffButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.ledOffButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ledOffButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ledOffButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.ledOffButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.ledOffButton.Location = new System.Drawing.Point(13, 46);
            this.ledOffButton.Name = "ledOffButton";
            this.ledOffButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ledOffButton.Size = new System.Drawing.Size(108, 32);
            this.ledOffButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.ledOffButton.TabIndex = 4;
            this.ledOffButton.Text = "Led Off";
            this.ledOffButton.TextColor = System.Drawing.Color.White;
            this.ledOffButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.ledOffButton.Click += new System.EventHandler(this.ledOffButton_Click);
            // 
            // ledOnButton
            // 
            this.ledOnButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.ledOnButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.ledOnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ledOnButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.ledOnButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ledOnButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ledOnButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.ledOnButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.ledOnButton.Location = new System.Drawing.Point(13, 8);
            this.ledOnButton.Name = "ledOnButton";
            this.ledOnButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.ledOnButton.Size = new System.Drawing.Size(108, 32);
            this.ledOnButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.ledOnButton.TabIndex = 3;
            this.ledOnButton.Text = "Led On";
            this.ledOnButton.TextColor = System.Drawing.Color.White;
            this.ledOnButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.ledOnButton.Click += new System.EventHandler(this.ledOnButton_Click);
            // 
            // webcamPanel
            // 
            this.webcamPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webcamPanel.Controls.Add(this.toggleWebcamButton);
            this.webcamPanel.Controls.Add(this.poisonProgressBar1);
            this.webcamPanel.Controls.Add(this.progressLabel);
            this.webcamPanel.Controls.Add(this.currentJobLabel);
            this.webcamPanel.Controls.Add(this.webcamPictureBox);
            this.webcamPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.webcamPanel.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.webcamPanel.Location = new System.Drawing.Point(12, 37);
            this.webcamPanel.Name = "webcamPanel";
            this.webcamPanel.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.webcamPanel.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.webcamPanel.Size = new System.Drawing.Size(448, 425);
            this.webcamPanel.TabIndex = 1;
            // 
            // toggleWebcamButton
            // 
            this.toggleWebcamButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.toggleWebcamButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.toggleWebcamButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleWebcamButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.toggleWebcamButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toggleWebcamButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toggleWebcamButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.toggleWebcamButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.toggleWebcamButton.Location = new System.Drawing.Point(162, 397);
            this.toggleWebcamButton.Name = "toggleWebcamButton";
            this.toggleWebcamButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.toggleWebcamButton.Size = new System.Drawing.Size(108, 23);
            this.toggleWebcamButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.toggleWebcamButton.TabIndex = 4;
            this.toggleWebcamButton.Text = "Preview On";
            this.toggleWebcamButton.TextColor = System.Drawing.Color.White;
            this.toggleWebcamButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.toggleWebcamButton.Click += new System.EventHandler(this.toggleWebcamButton_Click);
            // 
            // poisonProgressBar1
            // 
            this.poisonProgressBar1.Location = new System.Drawing.Point(9, 373);
            this.poisonProgressBar1.Name = "poisonProgressBar1";
            this.poisonProgressBar1.Size = new System.Drawing.Size(425, 18);
            this.poisonProgressBar1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.poisonProgressBar1.TabIndex = 3;
            this.poisonProgressBar1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progressLabel.Location = new System.Drawing.Point(332, 347);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(102, 23);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "Progress: --";
            // 
            // currentJobLabel
            // 
            this.currentJobLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentJobLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentJobLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.currentJobLabel.Location = new System.Drawing.Point(9, 347);
            this.currentJobLabel.Name = "currentJobLabel";
            this.currentJobLabel.Size = new System.Drawing.Size(317, 23);
            this.currentJobLabel.TabIndex = 1;
            this.currentJobLabel.Text = "Current Job: None";
            // 
            // webcamPictureBox
            // 
            this.webcamPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webcamPictureBox.Location = new System.Drawing.Point(9, 8);
            this.webcamPictureBox.Name = "webcamPictureBox";
            this.webcamPictureBox.Size = new System.Drawing.Size(425, 326);
            this.webcamPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.webcamPictureBox.TabIndex = 0;
            this.webcamPictureBox.TabStop = false;
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(677, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 0;
            // 
            // timerSyncInfo
            // 
            this.timerSyncInfo.Interval = 30000;
            // 
            // timerSyncDiscord
            // 
            this.timerSyncDiscord.Interval = 900000;
            // 
            // timerStatusUpdate
            // 
            this.timerStatusUpdate.Interval = 5000;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 845);
            this.Controls.Add(this.mainWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.mainWindow.ResumeLayout(false);
            this.nightPanel2.ResumeLayout(false);
            this.nightPanel3.ResumeLayout(false);
            this.filtrationPanel.ResumeLayout(false);
            this.fansPanel.ResumeLayout(false);
            this.tempsPanel.ResumeLayout(false);
            this.basicInfoPanel.ResumeLayout(false);
            this.nightPanel1.ResumeLayout(false);
            this.modelPreviewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modelPreviewImg)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.webcamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webcamPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        public ReaLTaiizor.Controls.HopeButton clearPlatformButton;

        internal System.Windows.Forms.Timer timerStatusUpdate;

        private System.Windows.Forms.Timer timerSyncDiscord;

        private System.Windows.Forms.Timer timerSyncInfo;

        public ReaLTaiizor.Controls.HopeButton setSpeedOffsetButton;
        public ReaLTaiizor.Controls.HopeButton setZaxisOffsetButton;

        public ReaLTaiizor.Controls.NightLabel zAxisOffsetLabel;

        public ReaLTaiizor.Controls.NightLabel filamentTypeLabel;
        public ReaLTaiizor.Controls.NightLabel speedOffsetLabel;

        public ReaLTaiizor.Controls.NightLabel nozzleSizeLabel;

        public ReaLTaiizor.Controls.NightPanel nightPanel3;

        public ReaLTaiizor.Controls.NightLabel coolingFanLabel;
        public ReaLTaiizor.Controls.NightLabel chamberFanLabel;
        public ReaLTaiizor.Controls.HopeButton setCoolingFanButton;
        public ReaLTaiizor.Controls.HopeButton setChamberFanButton;
        public ReaLTaiizor.Controls.NightLabel printerStatusLabel;
        public ReaLTaiizor.Controls.NightLabel totalRunTimeLabel;
        public ReaLTaiizor.Controls.NightLabel totalFilamentLabel;
        public ReaLTaiizor.Controls.ForeverListBox logBox;

        public ReaLTaiizor.Controls.NightLabel tvocLabel;
        public ReaLTaiizor.Controls.HopeButton externalFiltrationButton;
        public ReaLTaiizor.Controls.HopeButton internalFiltrationButton;
        public ReaLTaiizor.Controls.HopeButton disableFiltrationButton;
        public ReaLTaiizor.Controls.NightLabel bedTempLabel;
        public ReaLTaiizor.Controls.NightLabel extruderTempLabel;
        public ReaLTaiizor.Controls.HopeButton setBedTempButton;
        public ReaLTaiizor.Controls.HopeButton setExtruderTempButton;
        public ReaLTaiizor.Controls.HopeButton disableBedHeatButton;
        public ReaLTaiizor.Controls.HopeButton disableExtruderHeatButton;

        public ReaLTaiizor.Controls.NightPanel tempsPanel;
        public ReaLTaiizor.Controls.NightPanel fansPanel;
        public ReaLTaiizor.Controls.NightPanel filtrationPanel;
        public ReaLTaiizor.Controls.NightLabel filterModeLabel;

        public ReaLTaiizor.Controls.NightPanel basicInfoPanel;

        public ReaLTaiizor.Controls.NightLabel layerLabel;
        public ReaLTaiizor.Controls.NightLabel etaLabel;
        public ReaLTaiizor.Controls.NightLabel jobTimeLabel;
        public ReaLTaiizor.Controls.NightLabel weightLabel;
        public ReaLTaiizor.Controls.NightLabel lengthLabel;

        public ReaLTaiizor.Controls.HopeButton toggleWebcamButton;
        public ReaLTaiizor.Controls.NightLabel modelPreviewLabel;
        public ReaLTaiizor.Controls.NightLabel jobInfoLabel;
        public ReaLTaiizor.Controls.NightLabel mainStatusLabel;

        public ReaLTaiizor.Controls.NightLabel currentJobLabel;
        public ReaLTaiizor.Controls.PoisonProgressBar poisonProgressBar1;

        public System.Windows.Forms.PictureBox modelPreviewImg;
        public System.Windows.Forms.PictureBox webcamPictureBox;
        public ReaLTaiizor.Controls.NightLabel progressLabel;

        public ReaLTaiizor.Controls.HopeButton homeAxesButton;
        public ReaLTaiizor.Controls.HopeButton uploadJobButton;
        public ReaLTaiizor.Controls.HopeButton startRecentJobButton;
        public ReaLTaiizor.Controls.HopeButton startLocalJobButton;
        public ReaLTaiizor.Controls.HopeButton sendCmdButton;

        public ReaLTaiizor.Controls.HopeButton stopJobButton;
        public ReaLTaiizor.Controls.HopeButton swapFilamentButton;

        public ReaLTaiizor.Controls.HopeButton pauseJobButton;
        public ReaLTaiizor.Controls.HopeButton resumeJobButton;

        public ReaLTaiizor.Controls.HopeButton ledOnButton;

        public ReaLTaiizor.Controls.HopeButton ledOffButton;

        public ReaLTaiizor.Controls.NightPanel nightPanel2;

        public ReaLTaiizor.Controls.NightPanel nightPanel1;

        public ReaLTaiizor.Controls.NightPanel modelPreviewPanel;

        public ReaLTaiizor.Controls.NightPanel controlPanel;

        public ReaLTaiizor.Controls.NightPanel webcamPanel;

        public ReaLTaiizor.Controls.NightControlBox nightControlBox1;

        public ReaLTaiizor.Forms.NightForm mainWindow;

        #endregion
    }
}