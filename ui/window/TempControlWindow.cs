using System;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api.misc;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class TempControlWindow : Form
    {
        private MainMenu _ui;
        private readonly string _mode;
        private System.Windows.Forms.Timer _updateTimer;

        
        public TempControlWindow(MainMenu mainMenu, string mode)
        {
            InitializeComponent();
            _ui = mainMenu;
            _mode = mode;

            Shown += (s, e) =>
            {
                if (_ui.Config.AlwaysOnTop) _ui.UiHelper.SetOnTop(Handle);
                if (_ui.Config.AudioAlerts) SystemSounds.Exclamation.Play();
                Init();
            };
            
            FormClosing += (s, e) => 
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                
                if (_updateTimer != null && _updateTimer.Enabled)
                {
                    _updateTimer.Stop();
                    _updateTimer.Dispose();
                }
            };
        }

        private void Init()
        {
            // Set window title based on mode
            if (_mode.Equals("platform"))
            {
                headerLabel.Text = "Platform";
                nightForm1.Text = "Platform Temperature";
            }
            else
            {
                headerLabel.Text = "Extruder";
                nightForm1.Text = "Extruder Temperature";
            }

            // Setup and start the update timer
            _updateTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000,
                Enabled = true
            };
            _updateTimer.Tick += UpdateTemperature_Tick;
            
            UpdateTemperature();
        }

        private async void UpdateTemperature_Tick(object sender, EventArgs e)
        {
            await UpdateTemperature();
        }
        
        private async Task UpdateTemperature()
        {
            try
            {
                var info = await _ui.PrinterClient.Info.Get();
                if (_mode.Equals("platform")) tempLabel.Text = $"Current: {info.PrintBedTemp.AsInt()} | Set: {info.PrintBedSetTemp.AsInt()}";
                else tempLabel.Text = $"Current: {info.ExtruderTemp.AsInt()} | Set: {info.ExtruderSetTemp.AsInt()}";
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    _ui.AppendLog($"Error updating temperature: {ex.Message}");
                }
            }
        }

        private async void setButton_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!int.TryParse(tempBox.Text, out int temperature))
            {
                MessageBox.Show("Please enter a valid number for temperature", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check against maximum values
            var maxTemp = _mode.Equals("platform") ? 110 : 280; // Bed max = 110°C, Extruder max = 280°C
            
            if (temperature < 0 || temperature > maxTemp)
            {
                MessageBox.Show($"Temperature must be between 0 and {maxTemp} degrees", "Temperature Out Of Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                bool success;
                if (_mode.Equals("platform"))
                {
                    success = await _ui.PrinterClient.TempControl.SetBedTemp(temperature);
                    if (success) _ui.AppendLog($"Bed temperature set to {temperature}°C");
                    else MessageBox.Show("Failed to set bed temperature!", "Temperature Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // extruder
                {
                    success = await _ui.PrinterClient.TempControl.SetExtruderTemp(temperature);
                    if (success) _ui.AppendLog($"Extruder temperature set to {temperature}°C");
                    else MessageBox.Show("Failed to set extruder temperature!", "Temperature Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!success) return;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _ui.AppendLog($"Error setting temperature: {ex.Message}");
                MessageBox.Show($"Error setting temperature: {ex.Message}", "Temperature Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _ui.AppendLog($"Setting {_mode} temperature cancelled.");
            // Set dialog result and close the window
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}