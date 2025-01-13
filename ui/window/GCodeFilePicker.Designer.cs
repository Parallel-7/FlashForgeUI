using System.ComponentModel;

namespace FlashForgeUI
{
    partial class GCodeFilePicker
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
            this.nightForm1 = new ReaLTaiizor.Forms.NightForm();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.autoLevelCheckBox = new ReaLTaiizor.Controls.HopeCheckBox();
            this.startNowCheckBox = new ReaLTaiizor.Controls.HopeCheckBox();
            this.cancelButton = new ReaLTaiizor.Controls.HopeButton();
            this.okButton = new ReaLTaiizor.Controls.HopeButton();
            this.nightPanel2 = new ReaLTaiizor.Controls.NightPanel();
            this.sliceTimeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.sliceDateLabel = new ReaLTaiizor.Controls.NightLabel();
            this.slicerVersionLabel = new ReaLTaiizor.Controls.NightLabel();
            this.slicerLabel = new ReaLTaiizor.Controls.NightLabel();
            this.filamentTypeLabel = new ReaLTaiizor.Controls.NightLabel();
            this.filamentUsedLabel = new ReaLTaiizor.Controls.NightLabel();
            this.printerModelLabel = new ReaLTaiizor.Controls.NightLabel();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.nightPanel1 = new ReaLTaiizor.Controls.NightPanel();
            this.etaLabel = new ReaLTaiizor.Controls.NightLabel();
            this.browseButton = new ReaLTaiizor.Controls.HopeButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.nightForm1.SuspendLayout();
            this.nightPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            this.nightPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nightForm1
            // 
            this.nightForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.nightForm1.Controls.Add(this.nightControlBox1);
            this.nightForm1.Controls.Add(this.autoLevelCheckBox);
            this.nightForm1.Controls.Add(this.startNowCheckBox);
            this.nightForm1.Controls.Add(this.cancelButton);
            this.nightForm1.Controls.Add(this.okButton);
            this.nightForm1.Controls.Add(this.nightPanel2);
            this.nightForm1.Controls.Add(this.pictureBoxThumbnail);
            this.nightForm1.Controls.Add(this.nightPanel1);
            this.nightForm1.Controls.Add(this.browseButton);
            this.nightForm1.Controls.Add(this.textBox1);
            this.nightForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nightForm1.DrawIcon = false;
            this.nightForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nightForm1.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.nightForm1.Location = new System.Drawing.Point(0, 0);
            this.nightForm1.MinimumSize = new System.Drawing.Size(100, 42);
            this.nightForm1.Name = "nightForm1";
            this.nightForm1.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.nightForm1.Size = new System.Drawing.Size(800, 450);
            this.nightForm1.TabIndex = 0;
            this.nightForm1.Text = "Select a File";
            this.nightForm1.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            this.nightForm1.TitleBarTextColor = System.Drawing.Color.Gainsboro;
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
            this.nightControlBox1.Location = new System.Drawing.Point(661, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 14;
            // 
            // autoLevelCheckBox
            // 
            this.autoLevelCheckBox.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.autoLevelCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoLevelCheckBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.autoLevelCheckBox.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.autoLevelCheckBox.Enable = true;
            this.autoLevelCheckBox.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.autoLevelCheckBox.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.autoLevelCheckBox.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.autoLevelCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.autoLevelCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.autoLevelCheckBox.Location = new System.Drawing.Point(645, 63);
            this.autoLevelCheckBox.Name = "autoLevelCheckBox";
            this.autoLevelCheckBox.Size = new System.Drawing.Size(108, 20);
            this.autoLevelCheckBox.TabIndex = 13;
            this.autoLevelCheckBox.Text = "Auto Level";
            this.autoLevelCheckBox.UseVisualStyleBackColor = true;
            // 
            // startNowCheckBox
            // 
            this.startNowCheckBox.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.startNowCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startNowCheckBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.startNowCheckBox.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.startNowCheckBox.Enable = true;
            this.startNowCheckBox.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.startNowCheckBox.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.startNowCheckBox.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.startNowCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.startNowCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.startNowCheckBox.Location = new System.Drawing.Point(493, 63);
            this.startNowCheckBox.Name = "startNowCheckBox";
            this.startNowCheckBox.Size = new System.Drawing.Size(104, 20);
            this.startNowCheckBox.TabIndex = 12;
            this.startNowCheckBox.Text = "Start Now";
            this.startNowCheckBox.UseVisualStyleBackColor = true;
            this.startNowCheckBox.CheckedChanged += new System.EventHandler(this.startNowCheckBox_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.cancelButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.cancelButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cancelButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.cancelButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.cancelButton.Location = new System.Drawing.Point(400, 404);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.cancelButton.Size = new System.Drawing.Size(87, 34);
            this.cancelButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextColor = System.Drawing.Color.White;
            this.cancelButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.okButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.okButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.okButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.okButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.okButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.okButton.Location = new System.Drawing.Point(263, 403);
            this.okButton.Name = "okButton";
            this.okButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.okButton.Size = new System.Drawing.Size(87, 34);
            this.okButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.okButton.TabIndex = 10;
            this.okButton.Text = "Ok";
            this.okButton.TextColor = System.Drawing.Color.White;
            this.okButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nightPanel2
            // 
            this.nightPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nightPanel2.Controls.Add(this.sliceTimeLabel);
            this.nightPanel2.Controls.Add(this.sliceDateLabel);
            this.nightPanel2.Controls.Add(this.slicerVersionLabel);
            this.nightPanel2.Controls.Add(this.slicerLabel);
            this.nightPanel2.Controls.Add(this.filamentTypeLabel);
            this.nightPanel2.Controls.Add(this.filamentUsedLabel);
            this.nightPanel2.Controls.Add(this.printerModelLabel);
            this.nightPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightPanel2.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel2.Location = new System.Drawing.Point(22, 106);
            this.nightPanel2.Name = "nightPanel2";
            this.nightPanel2.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel2.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.nightPanel2.Size = new System.Drawing.Size(235, 331);
            this.nightPanel2.TabIndex = 9;
            // 
            // sliceTimeLabel
            // 
            this.sliceTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sliceTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliceTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sliceTimeLabel.Location = new System.Drawing.Point(3, 282);
            this.sliceTimeLabel.Name = "sliceTimeLabel";
            this.sliceTimeLabel.Size = new System.Drawing.Size(227, 34);
            this.sliceTimeLabel.TabIndex = 7;
            this.sliceTimeLabel.Text = "Time: ";
            // 
            // sliceDateLabel
            // 
            this.sliceDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.sliceDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliceDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sliceDateLabel.Location = new System.Drawing.Point(3, 248);
            this.sliceDateLabel.Name = "sliceDateLabel";
            this.sliceDateLabel.Size = new System.Drawing.Size(227, 34);
            this.sliceDateLabel.TabIndex = 6;
            this.sliceDateLabel.Text = "Date: ";
            // 
            // slicerVersionLabel
            // 
            this.slicerVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.slicerVersionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slicerVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.slicerVersionLabel.Location = new System.Drawing.Point(3, 214);
            this.slicerVersionLabel.Name = "slicerVersionLabel";
            this.slicerVersionLabel.Size = new System.Drawing.Size(227, 34);
            this.slicerVersionLabel.TabIndex = 5;
            this.slicerVersionLabel.Text = "Version: ";
            // 
            // slicerLabel
            // 
            this.slicerLabel.BackColor = System.Drawing.Color.Transparent;
            this.slicerLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slicerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.slicerLabel.Location = new System.Drawing.Point(3, 180);
            this.slicerLabel.Name = "slicerLabel";
            this.slicerLabel.Size = new System.Drawing.Size(227, 34);
            this.slicerLabel.TabIndex = 4;
            this.slicerLabel.Text = "Slicer: ";
            // 
            // filamentTypeLabel
            // 
            this.filamentTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.filamentTypeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filamentTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.filamentTypeLabel.Location = new System.Drawing.Point(3, 73);
            this.filamentTypeLabel.Name = "filamentTypeLabel";
            this.filamentTypeLabel.Size = new System.Drawing.Size(227, 34);
            this.filamentTypeLabel.TabIndex = 3;
            this.filamentTypeLabel.Text = "Filament Type: ";
            // 
            // filamentUsedLabel
            // 
            this.filamentUsedLabel.BackColor = System.Drawing.Color.Transparent;
            this.filamentUsedLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filamentUsedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.filamentUsedLabel.Location = new System.Drawing.Point(3, 107);
            this.filamentUsedLabel.Name = "filamentUsedLabel";
            this.filamentUsedLabel.Size = new System.Drawing.Size(227, 34);
            this.filamentUsedLabel.TabIndex = 2;
            this.filamentUsedLabel.Text = "Filament Used: ";
            // 
            // printerModelLabel
            // 
            this.printerModelLabel.BackColor = System.Drawing.Color.Transparent;
            this.printerModelLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerModelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.printerModelLabel.Location = new System.Drawing.Point(3, 9);
            this.printerModelLabel.Name = "printerModelLabel";
            this.printerModelLabel.Size = new System.Drawing.Size(227, 64);
            this.printerModelLabel.TabIndex = 1;
            this.printerModelLabel.Text = "Printer Model: ";
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(263, 155);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(224, 200);
            this.pictureBoxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxThumbnail.TabIndex = 8;
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // nightPanel1
            // 
            this.nightPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nightPanel1.Controls.Add(this.etaLabel);
            this.nightPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightPanel1.LeftSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel1.Location = new System.Drawing.Point(493, 106);
            this.nightPanel1.Name = "nightPanel1";
            this.nightPanel1.RightSideColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nightPanel1.Side = ReaLTaiizor.Controls.NightPanel.PanelSide.Left;
            this.nightPanel1.Size = new System.Drawing.Size(295, 332);
            this.nightPanel1.TabIndex = 2;
            // 
            // etaLabel
            // 
            this.etaLabel.BackColor = System.Drawing.Color.Transparent;
            this.etaLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.etaLabel.Location = new System.Drawing.Point(3, 12);
            this.etaLabel.Name = "etaLabel";
            this.etaLabel.Size = new System.Drawing.Size(287, 34);
            this.etaLabel.TabIndex = 0;
            this.etaLabel.Text = "Estimated Print Time: ";
            // 
            // browseButton
            // 
            this.browseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.browseButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.browseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.browseButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.browseButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.browseButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.browseButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.browseButton.Location = new System.Drawing.Point(370, 60);
            this.browseButton.Name = "browseButton";
            this.browseButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.browseButton.Size = new System.Drawing.Size(102, 23);
            this.browseButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse...";
            this.browseButton.TextColor = System.Drawing.Color.White;
            this.browseButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Location = new System.Drawing.Point(22, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(310, 23);
            this.textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "G-code and 3MF files (*.gcode;*.3mf)|*.gcode;*.3mf|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Select a G-code or 3MF file";
            // 
            // GCodeFilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nightForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "GCodeFilePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewGCodeFilePicker";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.nightForm1.ResumeLayout(false);
            this.nightForm1.PerformLayout();
            this.nightPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            this.nightPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private ReaLTaiizor.Controls.NightLabel slicerVersionLabel;
        private ReaLTaiizor.Controls.NightLabel sliceDateLabel;
        private ReaLTaiizor.Controls.NightLabel sliceTimeLabel;

        private ReaLTaiizor.Controls.NightLabel slicerLabel;

        private ReaLTaiizor.Controls.NightLabel filamentTypeLabel;

        private ReaLTaiizor.Controls.NightLabel filamentUsedLabel;

        private ReaLTaiizor.Controls.NightLabel printerModelLabel;

        private ReaLTaiizor.Controls.HopeCheckBox autoLevelCheckBox;

        private ReaLTaiizor.Controls.HopeCheckBox startNowCheckBox;

        private ReaLTaiizor.Controls.HopeButton okButton;
        private ReaLTaiizor.Controls.HopeButton cancelButton;

        private ReaLTaiizor.Controls.NightPanel nightPanel2;

        private System.Windows.Forms.PictureBox pictureBoxThumbnail;

        private ReaLTaiizor.Controls.NightLabel etaLabel;

        private ReaLTaiizor.Controls.NightPanel nightPanel1;

        private ReaLTaiizor.Controls.HopeButton browseButton;

        private System.Windows.Forms.TextBox textBox1;

        private ReaLTaiizor.Forms.NightForm nightForm1;

        #endregion
    }
}