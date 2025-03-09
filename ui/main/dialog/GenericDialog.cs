using System;
using System.Media;
using System.Windows.Forms;

namespace FlashForgeUI.ui.main.dialog
{
    public partial class GenericDialog : Form
    {
        public GenericDialog(string windowTitle, string title, string message, MainMenu mainMenu)
        {
            InitializeComponent();
            
            
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

            Shown += (s, e) =>
            {
                titleLabel.Text = title;
                textLabel.Text = message;
                GenericDialogForm.Text = windowTitle;
                if (mainMenu.Config.AlwaysOnTop) mainMenu.UiHelper.SetOnTop(Handle);
                // play sound if enabled ?
                if (mainMenu.Config.AudioAlerts) SystemSounds.Exclamation.Play();
            };

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}