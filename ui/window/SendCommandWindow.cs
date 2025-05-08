using System;
using System.Windows.Forms;
using FiveMApi.tcpapi;
using FlashForgeUI.ui.main.util;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class SendCommandWindow : Form
    {
        private readonly FlashForgeClient _tcpClient;
        
        public SendCommandWindow(FlashForgeClient tcpClient, MainMenu mainMenu)
        {
            _tcpClient = tcpClient;
            InitializeComponent();
            
            Shown += (s, e) =>
            {
                if (mainMenu.Config.AlwaysOnTop) mainMenu.UiHelper.SetOnTop(Handle);
            };
            
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
        
        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(commandBox.Text)) return;
            AppendLog("Executing command...");
            var response = await _tcpClient.SendRawCmd(commandBox.Text);
            AppendLog(string.IsNullOrEmpty(response) ? "Bad command/invalid response" : $"Response: {response}");
            commandBox.Text = "";
        }
        
        private void AppendLog(string text)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new Action(() => {
                    logBox.AppendText(text + Environment.NewLine);
                    logBox.SelectionStart = logBox.TextLength;
                    logBox.ScrollToCaret();
                }));
            }
            else
            {
                logBox.AppendText(text + Environment.NewLine);
                logBox.SelectionStart = logBox.TextLength;
                logBox.ScrollToCaret();
            }
        }
    }
}