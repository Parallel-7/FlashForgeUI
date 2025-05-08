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

        public SettingsWindow(MainMenu ui)
        {
            InitializeComponent();
            _ui = ui;

            LoadConfigToUI();

            Shown += (s, e) =>
            {
                if (_ui.Config.AlwaysOnTop) _ui.UiHelper.SetOnTop(Handle);
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

            audioAlertCheck.Checked = _ui.Config.AudioAlerts;
            visualAlertCheck.Checked = _ui.Config.VisualAlerts;

            alertWhenCooledCheck.Checked = _ui.Config.AlertWhenCooled;
            alertWhenDoneCheck.Checked = _ui.Config.AlertWhenComplete;

            customLedsCheck.Checked = _ui.Config.CustomLeds;
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
                    _ui.UiHelper.ShowDialog("Invalid camera URL", "Invalid camera URL!", "Please enter your camera URL before enabling", false);
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
                    _ui.UiHelper.ShowDialog("Invalid webhook URL", "Invalid webhook URL!", "Please enter your webhook URL before enabling", false);
                    return;
                }

                _ui.Config.DiscordSync = true;
                _ui.Config.WebhookUrl = discordWebhookBox.Text;
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

        private void alertWhenDoneCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.AlertWhenComplete = alertWhenDoneCheck.Checked;
            Save();
        }

        private void alertWhenCooledCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.AlertWhenCooled = alertWhenCooledCheck.Checked;
            Save();
        }


        private void visualAlertCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.VisualAlerts = visualAlertCheck.Checked;
            Save();
        }

        private void audioAlertCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.AudioAlerts = audioAlertCheck.Checked;
            Save();
        }

        private void customLedsCheck_CheckedChanged(object sender, EventArgs e)
        {
            _ui.Config.CustomLeds = customLedsCheck.Checked;
            Save();
        }
    }
}