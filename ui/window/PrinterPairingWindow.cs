using System;
using System.Windows.Forms;
using FlashForgeUI.ui.main.util;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class PrinterPairingWindow : Form
    {
        
        public string CheckCode { get; private set; }
        
        public PrinterPairingWindow(MainMenu mainMenu)
        {
            InitializeComponent();
            
            Shown += (s, e) =>
            {
                if (mainMenu.Config.AlwaysOnTop)
                {
                    var _uiHelper = new UiHelper(mainMenu);
                    _uiHelper.SetOnTop(Handle);
                }
            };
            
            // the "default" NightControlBox just closes the application when exit is clicked..??
            FormClosing += (s, e) => 
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            };
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                CheckCode = textBox1.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter the check code.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}