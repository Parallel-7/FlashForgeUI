using System;
using System.Windows.Forms;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class SettingsWindow : Form
    {
        private MainMenu _ui;
        
        public SettingsWindow(MainMenu ui)
        {
            InitializeComponent();
            _ui = ui;
            
            LoadConfigToUI();
            
            FormClosing += (s, e) => 
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    if (_ui.config.WebUi && !_ui.webServer.Running) _ui.webServer.Start();
                    else if (!ui.config.WebUi && ui.webServer.Running) _ui.webServer.Stop();
                    Close();
                }
            };
            
        }

        private void Save()
        {
            _ui.config.Save();
        }
        
        private void LoadConfigToUI()
        {
            // custom camera & box
            if (_ui.config.CustomCamera)
            {
                customCameraBox.Text = _ui.config.CustomCameraUrl;
                customCameraCheck.Checked = true;
            }

            // discord sync & webhook
            if (_ui.config.DiscordSync)
            {
                discordWebhookBox.Text = _ui.config.WebhookUrl;
                discordSyncCheck.Checked = true;
            }

            // webUI toggle
            webUICheck.Checked = _ui.config.WebUi;
        }

        private void webUICheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.config.WebUi = webUICheck.Checked;
            Save();
        }

        private void customCameraCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (customCameraCheck.Checked)
            {
                if (string.IsNullOrEmpty(customCameraBox.Text))
                {
                    MessageBox.Show("Please enter your camera's URL first!", "No camera URL");
                    return;
                }

                _ui.config.CustomCamera = true;
                _ui.config.CustomCameraUrl = customCameraBox.Text;
                Save();
            }
            else _ui.config.CustomCamera = false;
            Save();
        }

        private void discordSyncCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (discordSyncCheck.Checked)
            {
                if (string.IsNullOrEmpty(discordWebhookBox.Text))
                {
                    MessageBox.Show("Please enter your discord webhook first!", "No webhook URL");
                    return;
                }

                _ui.config.DiscordSync = true;
                _ui.config.WebhookUrl = customCameraBox.Text;
                Save();
            }
            else _ui.config.DiscordSync = false;
            Save();
        }
    }
}