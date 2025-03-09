using System.ComponentModel;

namespace FlashForgeUI.ui.main.dialog
{
    partial class GenericDialog
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
            this.GenericDialogForm = new ReaLTaiizor.Forms.NightForm();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.okButton = new ReaLTaiizor.Controls.HopeButton();
            this.textLabel = new ReaLTaiizor.Controls.NightLabel();
            this.titleLabel = new ReaLTaiizor.Controls.NightHeaderLabel();
            this.GenericDialogForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenericDialogForm
            // 
            this.GenericDialogForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.GenericDialogForm.Controls.Add(this.nightControlBox1);
            this.GenericDialogForm.Controls.Add(this.okButton);
            this.GenericDialogForm.Controls.Add(this.textLabel);
            this.GenericDialogForm.Controls.Add(this.titleLabel);
            this.GenericDialogForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenericDialogForm.DrawIcon = false;
            this.GenericDialogForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GenericDialogForm.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.GenericDialogForm.Location = new System.Drawing.Point(0, 0);
            this.GenericDialogForm.MinimumSize = new System.Drawing.Size(100, 42);
            this.GenericDialogForm.Name = "GenericDialogForm";
            this.GenericDialogForm.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.GenericDialogForm.Size = new System.Drawing.Size(455, 264);
            this.GenericDialogForm.TabIndex = 0;
            this.GenericDialogForm.Text = "nightForm1";
            this.GenericDialogForm.TextAlignment = ReaLTaiizor.Forms.NightForm.Alignment.Left;
            this.GenericDialogForm.TitleBarTextColor = System.Drawing.Color.Gainsboro;
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
            this.nightControlBox1.Location = new System.Drawing.Point(316, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 3;
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
            this.okButton.Location = new System.Drawing.Point(166, 213);
            this.okButton.Name = "okButton";
            this.okButton.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.okButton.Size = new System.Drawing.Size(128, 39);
            this.okButton.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.TextColor = System.Drawing.Color.White;
            this.okButton.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.BackColor = System.Drawing.Color.Transparent;
            this.textLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textLabel.Location = new System.Drawing.Point(12, 115);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(431, 69);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "Text";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.titleLabel.LeftSideForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.titleLabel.Location = new System.Drawing.Point(12, 43);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightSideForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(176)))));
            this.titleLabel.Side = ReaLTaiizor.Controls.NightHeaderLabel.PanelSide.LeftPanel;
            this.titleLabel.Size = new System.Drawing.Size(431, 56);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.titleLabel.UseCompatibleTextRendering = true;
            // 
            // GenericDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 264);
            this.Controls.Add(this.GenericDialogForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "GenericDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenericDialog";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.GenericDialogForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;

        private ReaLTaiizor.Controls.HopeButton okButton;

        private ReaLTaiizor.Controls.NightLabel textLabel;

        private ReaLTaiizor.Controls.NightHeaderLabel titleLabel;

        private ReaLTaiizor.Forms.NightForm GenericDialogForm;

        #endregion
    }
}