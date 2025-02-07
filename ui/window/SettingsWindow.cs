using System;
using System.Diagnostics;
using System.Windows.Forms;
using FlashForgeUI.ui.main.util;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class SettingsWindow : Form
    {
        private MainMenu _ui;
        private readonly UiHelper _uiHelper; 
        
        public SettingsWindow(MainMenu ui)
        {
            InitializeComponent();
            _ui = ui;
            _uiHelper = new UiHelper(_ui);
            
            LoadConfigToUI();

            Shown += (s, e) =>
            {
                if (_ui.Config.AlwaysOnTop) _uiHelper.SetOnTop(Handle);
            };
            
            FormClosing += (s, e) => 
            {
                Debug.WriteLine(e.CloseReason.ToString());
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            };
            
        }

        private void Save()
        {
            _ui.Config.Save();
        }
        
        private void LoadConfigToUI()
        {
            // custom camera & box
            if (_ui.Config.CustomCamera)
            {
                customCameraBox.Text = _ui.Config.CustomCameraUrl;
                customCameraCheck.Checked = true;
            }

            // discord sync & webhook
            if (_ui.Config.DiscordSync)
            {
                discordWebhookBox.Text = _ui.Config.WebhookUrl;
                discordSyncCheck.Checked = true;
            }

            // webUI toggle
            webUICheck.Checked = _ui.Config.WebUi;
            
            // debug mode toggle
            debugCheck.Checked = _ui.Config.DebugMode;
            
            // always on top toggle
            alwaysOnTopCheck.Checked = _ui.Config.AlwaysOnTop;
        }

        private void webUICheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.WebUi = webUICheck.Checked;
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

                _ui.Config.CustomCamera = true;
                _ui.Config.CustomCameraUrl = customCameraBox.Text;
                Save();
            }
            else _ui.Config.CustomCamera = false;
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

                _ui.Config.DiscordSync = true;
                _ui.Config.WebhookUrl = customCameraBox.Text;
                Save();
            }
            else _ui.Config.DiscordSync = false;
            Save();
        }

        private void debugCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.DebugMode = debugCheck.Checked;
            Save();
        }

        private void alwaysOnTopCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.AlwaysOnTop = alwaysOnTopCheck.Checked;
            Save();
        }
    }
}