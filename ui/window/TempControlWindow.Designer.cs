using System.ComponentModel;

namespace FlashForgeUI
{
    partial class TempControlWindow
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
            this.cancelButton = new ReaLTaiizor.Controls.HopeButton();
            this.setButton = new ReaLTaiizor.Controls.HopeButton();
            this.tempBox = new System.Windows.Forms.TextBox();
            this.tempLabel = new ReaLTaiizor.Controls.NightLabel();
            this.headerLabel = new ReaLTaiizor.Controls.NightHeaderLabel();
            this.nightForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nightForm1
            // 
            this.nightForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.nightForm1.Controls.Add(this.cancelButton);
            this.nightForm1.Controls.Add(this.setButton);
            this.nightForm1.Controls.Add(this.tempBox);
            this.nightForm1.Controls.Add(this.tempLabel);
            this.nightForm1.Controls.Add(this.headerLabel);
            this.nightForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nightForm1.DrawIcon = false;
            this.nightForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nightForm1.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.nightForm1.Location = new System.Drawing.Point(0, 0);
            this.nightForm1.MinimumSize = new System.Drawing.Size(100, 42);
            this.nightForm1.Name = "nightForm1";
            this.nightForm1.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.nightForm1.Size = new System.Drawing.Size(469, 273);
            this.nightForm1.TabIndex = 0;
            this.nightForm1.Text = "nightForm1";
            this.nightForm1.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            this.nightForm1.TitleBarTextColor = System.Drawing.Color.Gainsboro;
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
            this.cancelButton.Location = new System.Drawing.Point(252, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.cancelButton.Size = new System.Drawing.Size(100, 35);
            this.cancelButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextColor = System.Drawing.Color.White;
            this.cancelButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // setButton
            // 
            this.setButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.setButton.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.setButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setButton.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.setButton.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.setButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.setButton.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.setButton.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.setButton.Location = new System.Drawing.Point(127, 226);
            this.setButton.Name = "setButton";
            this.setButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.setButton.Size = new System.Drawing.Size(100, 35);
            this.setButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.setButton.TabIndex = 3;
            this.setButton.Text = "Set";
            this.setButton.TextColor = System.Drawing.Color.White;
            this.setButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // tempBox
            // 
            this.tempBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tempBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tempBox.Location = new System.Drawing.Point(127, 173);
            this.tempBox.Name = "tempBox";
            this.tempBox.Size = new System.Drawing.Size(225, 23);
            this.tempBox.TabIndex = 2;
            // 
            // tempLabel
            // 
            this.tempLabel.BackColor = System.Drawing.Color.Transparent;
            this.tempLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tempLabel.Location = new System.Drawing.Point(79, 106);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(312, 45);
            this.tempLabel.TabIndex = 1;
            this.tempLabel.Text = "Current: 123/456";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.headerLabel.LeftSideForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.headerLabel.Location = new System.Drawing.Point(101, 52);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.RightSideForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(176)))));
            this.headerLabel.Side = ReaLTaiizor.Controls.NightHeaderLabel.PanelSide.LeftPanel;
            this.headerLabel.Size = new System.Drawing.Size(270, 54);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Extruder";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headerLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.headerLabel.UseCompatibleTextRendering = true;
            // 
            // TempControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 273);
            this.Controls.Add(this.nightForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "TempControlWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TempControl";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.nightForm1.ResumeLayout(false);
            this.nightForm1.PerformLayout();
            this.ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.HopeButton cancelButton;

        private ReaLTaiizor.Controls.HopeButton setButton;

        private System.Windows.Forms.TextBox tempBox;

        private ReaLTaiizor.Controls.NightLabel tempLabel;

        private ReaLTaiizor.Controls.NightHeaderLabel headerLabel;

        private ReaLTaiizor.Forms.NightForm nightForm1;

        #endregion
    }
}