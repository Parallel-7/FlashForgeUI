using System.ComponentModel;

namespace FlashForgeUI
{
    partial class SettingsWindow
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
            this.Settings = new ReaLTaiizor.Forms.NightForm();
            this.alwaysOnTopCheck = new ReaLTaiizor.Controls.HopeCheckBox();
            this.debugCheck = new ReaLTaiizor.Controls.HopeCheckBox();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.customCameraCheck = new ReaLTaiizor.Controls.HopeCheckBox();
            this.webUICheck = new ReaLTaiizor.Controls.HopeCheckBox();
            this.discordSyncCheck = new ReaLTaiizor.Controls.HopeCheckBox();
            this.discordWebhookBox = new System.Windows.Forms.TextBox();
            this.customCameraBox = new System.Windows.Forms.TextBox();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.Settings.Controls.Add(this.alwaysOnTopCheck);
            this.Settings.Controls.Add(this.debugCheck);
            this.Settings.Controls.Add(this.nightControlBox1);
            this.Settings.Controls.Add(this.customCameraCheck);
            this.Settings.Controls.Add(this.webUICheck);
            this.Settings.Controls.Add(this.discordSyncCheck);
            this.Settings.Controls.Add(this.discordWebhookBox);
            this.Settings.Controls.Add(this.customCameraBox);
            this.Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Settings.DrawIcon = false;
            this.Settings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Settings.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.Settings.Location = new System.Drawing.Point(0, 0);
            this.Settings.MinimumSize = new System.Drawing.Size(100, 42);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.Settings.Size = new System.Drawing.Size(553, 355);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Settings";
            this.Settings.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            this.Settings.TitleBarTextColor = System.Drawing.Color.Gainsboro;
            // 
            // alwaysOnTopCheck
            // 
            this.alwaysOnTopCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.alwaysOnTopCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alwaysOnTopCheck.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.alwaysOnTopCheck.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.alwaysOnTopCheck.Enable = true;
            this.alwaysOnTopCheck.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.alwaysOnTopCheck.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.alwaysOnTopCheck.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.alwaysOnTopCheck.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.alwaysOnTopCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.alwaysOnTopCheck.Location = new System.Drawing.Point(189, 63);
            this.alwaysOnTopCheck.Name = "alwaysOnTopCheck";
            this.alwaysOnTopCheck.Size = new System.Drawing.Size(137, 20);
            this.alwaysOnTopCheck.TabIndex = 9;
            this.alwaysOnTopCheck.Text = "Always On Top";
            this.alwaysOnTopCheck.UseVisualStyleBackColor = true;
            this.alwaysOnTopCheck.CheckedChanged += new System.EventHandler(this.alwaysOnTopCheck_CheckedChanged);
            // 
            // debugCheck
            // 
            this.debugCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.debugCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.debugCheck.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.debugCheck.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.debugCheck.Enable = true;
            this.debugCheck.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.debugCheck.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.debugCheck.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.debugCheck.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.debugCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.debugCheck.Location = new System.Drawing.Point(414, 63);
            this.debugCheck.Name = "debugCheck";
            this.debugCheck.Size = new System.Drawing.Size(81, 20);
            this.debugCheck.TabIndex = 8;
            this.debugCheck.Text = "Debug";
            this.debugCheck.UseVisualStyleBackColor = true;
            this.debugCheck.CheckedChanged += new System.EventHandler(this.debugCheck_CheckedChanged);
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
            this.nightControlBox1.Location = new System.Drawing.Point(414, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 7;
            // 
            // customCameraCheck
            // 
            this.customCameraCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.customCameraCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customCameraCheck.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.customCameraCheck.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.customCameraCheck.Enable = true;
            this.customCameraCheck.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.customCameraCheck.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.customCameraCheck.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.customCameraCheck.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.customCameraCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customCameraCheck.Location = new System.Drawing.Point(30, 113);
            this.customCameraCheck.Name = "customCameraCheck";
            this.customCameraCheck.Size = new System.Drawing.Size(147, 20);
            this.customCameraCheck.TabIndex = 6;
            this.customCameraCheck.Text = "Custom Camera";
            this.customCameraCheck.UseVisualStyleBackColor = true;
            this.customCameraCheck.CheckedChanged += new System.EventHandler(this.customCameraCheck_CheckedChanged);
            // 
            // webUICheck
            // 
            this.webUICheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.webUICheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webUICheck.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.webUICheck.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.webUICheck.Enable = true;
            this.webUICheck.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.webUICheck.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.webUICheck.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.webUICheck.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.webUICheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.webUICheck.Location = new System.Drawing.Point(30, 63);
            this.webUICheck.Name = "webUICheck";
            this.webUICheck.Size = new System.Drawing.Size(85, 20);
            this.webUICheck.TabIndex = 5;
            this.webUICheck.Text = "Web UI";
            this.webUICheck.UseVisualStyleBackColor = true;
            this.webUICheck.CheckedChanged += new System.EventHandler(this.webUICheck_CheckedChanged);
            // 
            // discordSyncCheck
            // 
            this.discordSyncCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.discordSyncCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discordSyncCheck.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.discordSyncCheck.DisabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.discordSyncCheck.Enable = true;
            this.discordSyncCheck.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.discordSyncCheck.EnabledStringColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.discordSyncCheck.EnabledUncheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.discordSyncCheck.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.discordSyncCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.discordSyncCheck.Location = new System.Drawing.Point(30, 175);
            this.discordSyncCheck.Name = "discordSyncCheck";
            this.discordSyncCheck.Size = new System.Drawing.Size(125, 20);
            this.discordSyncCheck.TabIndex = 4;
            this.discordSyncCheck.Text = "Discord Sync";
            this.discordSyncCheck.UseVisualStyleBackColor = true;
            this.discordSyncCheck.CheckedChanged += new System.EventHandler(this.discordSyncCheck_CheckedChanged);
            // 
            // discordWebhookBox
            // 
            this.discordWebhookBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.discordWebhookBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.discordWebhookBox.Location = new System.Drawing.Point(189, 176);
            this.discordWebhookBox.Name = "discordWebhookBox";
            this.discordWebhookBox.Size = new System.Drawing.Size(310, 23);
            this.discordWebhookBox.TabIndex = 3;
            // 
            // customCameraBox
            // 
            this.customCameraBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customCameraBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customCameraBox.Location = new System.Drawing.Point(189, 114);
            this.customCameraBox.Name = "customCameraBox";
            this.customCameraBox.Size = new System.Drawing.Size(310, 23);
            this.customCameraBox.TabIndex = 2;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 355);
            this.Controls.Add(this.Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsWindow";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.HopeCheckBox alwaysOnTopCheck;

        private ReaLTaiizor.Controls.HopeCheckBox debugCheck;

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;

        private ReaLTaiizor.Controls.HopeCheckBox discordSyncCheck;
        private ReaLTaiizor.Controls.HopeCheckBox webUICheck;

        private ReaLTaiizor.Controls.HopeCheckBox customCameraCheck;

        private System.Windows.Forms.TextBox customCameraBox;

        private System.Windows.Forms.TextBox discordWebhookBox;

        private ReaLTaiizor.Forms.NightForm Settings;

        #endregion
    }
}