using System.ComponentModel;
using System.Windows.Forms;

namespace FlashForgeUI
{
    partial class PrinterSelectionWindow
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
            this.listViewPrinters = new ReaLTaiizor.Controls.PoisonListView();
            this.columnHeaderPrinterName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderIpAddress = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSerialNumber = new System.Windows.Forms.ColumnHeader();
            this.nightForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nightForm1
            // 
            this.nightForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.nightForm1.Controls.Add(this.nightControlBox1);
            this.nightForm1.Controls.Add(this.listViewPrinters);
            this.nightForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nightForm1.DrawIcon = false;
            this.nightForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nightForm1.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.nightForm1.Location = new System.Drawing.Point(0, 0);
            this.nightForm1.MinimumSize = new System.Drawing.Size(100, 42);
            this.nightForm1.Name = "nightForm1";
            this.nightForm1.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.nightForm1.Size = new System.Drawing.Size(390, 290);
            this.nightForm1.TabIndex = 0;
            this.nightForm1.Text = "Select a Printer";
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
            this.nightControlBox1.Location = new System.Drawing.Point(251, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            // 
            // listViewPrinters
            // 
            this.listViewPrinters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listViewPrinters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeaderPrinterName, this.columnHeaderIpAddress, this.columnHeaderSerialNumber });
            this.listViewPrinters.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listViewPrinters.FullRowSelect = true;
            this.listViewPrinters.Location = new System.Drawing.Point(12, 46);
            this.listViewPrinters.Name = "listViewPrinters";
            this.listViewPrinters.OwnerDraw = true;
            this.listViewPrinters.Scrollable = false;
            this.listViewPrinters.Size = new System.Drawing.Size(366, 232);
            this.listViewPrinters.TabIndex = 0;
            this.listViewPrinters.UseCompatibleStateImageBehavior = false;
            this.listViewPrinters.UseSelectable = true;
            this.listViewPrinters.View = System.Windows.Forms.View.Details;
            this.listViewPrinters.ItemActivate += new System.EventHandler(this.listViewPrinters_ItemActivate);
            // 
            // columnHeaderPrinterName
            // 
            this.columnHeaderPrinterName.Text = "Printer Name";
            this.columnHeaderPrinterName.Width = 125;
            // 
            // columnHeaderIpAddress
            // 
            this.columnHeaderIpAddress.Text = "IP Address";
            this.columnHeaderIpAddress.Width = 110;
            // 
            // columnHeaderSerialNumber
            // 
            this.columnHeaderSerialNumber.Text = "Serial Number";
            this.columnHeaderSerialNumber.Width = 130;
            // 
            // NewPrinterSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 290);
            this.Controls.Add(this.nightForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "PrinterSelectionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPrinterSelectionForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.nightForm1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;

        private System.Windows.Forms.ColumnHeader columnHeaderPrinterName;
        private System.Windows.Forms.ColumnHeader columnHeaderIpAddress;
        private System.Windows.Forms.ColumnHeader columnHeaderSerialNumber;

        private ReaLTaiizor.Controls.PoisonListView listViewPrinters;

        private ReaLTaiizor.Forms.NightForm nightForm1;

        #endregion
    }
}