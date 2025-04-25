using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FlashForgeUI.ui.main.dialog;
using ReaLTaiizor.Controls;

namespace FlashForgeUI.ui.main.util
{
    /// <summary>
    /// Created to offload some UI code from StatusTimeManager,
    /// but may include other code in the future
    /// </summary>
    public class UiHelper
    {
        private readonly MainMenu _ui;

        public UiHelper(MainMenu form1)
        {
            _ui = form1;
        }
        
        public void HandleLostConnection()
        {
            _ui.etaLabel.Text = "ETA: --:--";
            _ui.jobTimeLabel.Text = "Job Time: --:--:--";
            _ui.currentJobLabel.Text = "Current Job: None";
            _ui.extruderTempLabel.Text = "Extruder: --/--";
            _ui.bedTempLabel.Text = "Bed: --/--";
            _ui.poisonProgressBar1.Value = 0;
            _ui.progressLabel.Text = "Progress: --";
            _ui.printerStatusLabel.Text = "Printer Status: --";
            _ui.tvocLabel.Text = "TVOC Level: --";
            _ui.layerLabel.Text = "Layer: --";
            _ui.weightLabel.Text = "Weight: --";
            _ui.lengthLabel.Text = "Length: --";
            _ui.AppendLog("Lost connection to printer.");
            _ui.MjpegStreamManager.Stop();
        }
        
        
        // Show controls that require an active job (firmware limitation)
        public void ShowJobRequiredControls()
        {
            _ui.setChamberFanButton.Visible = true;
            _ui.setCoolingFanButton.Visible = true;
            _ui.setSpeedOffsetButton.Visible = true;
            _ui.setZaxisOffsetButton.Visible = true;
            
        }
        
        // Hide controls that require an active job (same limitation)
        public void HideJobRequiredControls()
        {
            _ui.setChamberFanButton.Visible = false;
            _ui.setCoolingFanButton.Visible = false;
            _ui.setSpeedOffsetButton.Visible = false;
            _ui.setZaxisOffsetButton.Visible = false;
            
        }
        
        
        // Show controls that would interfere with an active job
        public void ShowJobInterferingControls()
        {
            _ui.homeAxesButton.Visible = true;
            _ui.startLocalJobButton.Visible = true;
            _ui.startRecentJobButton.Visible = true;
            _ui.uploadJobButton.Visible = true;
            _ui.sendCmdButton.Visible = true;
            _ui.swapFilamentButton.Visible = true;
            _ui.clearPlatformButton.Visible = true;
            ShowTempControls();
        }
        
        // Hide controls that would interfere with an active job
        public void HideJobInterferingControls()
        {
            _ui.homeAxesButton.Visible = false;
            _ui.startLocalJobButton.Visible = false;
            _ui.startRecentJobButton.Visible = false;
            _ui.uploadJobButton.Visible = false;
            _ui.sendCmdButton.Visible = false;
            _ui.swapFilamentButton.Visible = false;
            _ui.clearPlatformButton.Visible = false;
            HideTempControls();
        }
        
        // Hide / Show temp controls
        private void HideTempControls()
        {
            _ui.disableBedHeatButton.Visible = false;
            _ui.setBedTempButton.Visible = false;
            _ui.disableExtruderHeatButton.Visible = false;
            _ui.setExtruderTempButton.Visible = false;
        }

        private void ShowTempControls()
        {
            _ui.disableBedHeatButton.Visible = true;
            _ui.setBedTempButton.Visible = true;
            _ui.disableExtruderHeatButton.Visible = true;
            _ui.setExtruderTempButton.Visible = true;
        }

        private void SetPreviewImg(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                var image = Image.FromStream(ms);
                _ui.modelPreviewImg.BeginInvoke(new Action(() =>
                {
                    _ui.modelPreviewImg.Image?.Dispose();
                    _ui.modelPreviewImg.Image = image;
                }));
            }
        }
        
        public async Task UpdateModelPreview(string currentJobFileName)
        {
            if (!string.IsNullOrEmpty(currentJobFileName))
            {
                if (currentJobFileName != _ui.LastJobName)
                {
                    _ui.LastJobName = currentJobFileName;

                    // Fetch the thumbnail
                    var thumbnailBytes = await _ui.PrinterClient.Files.GetGCodeThumbnail(currentJobFileName);
                    
                    if (thumbnailBytes != null && thumbnailBytes.Length > 0) SetPreviewImg(thumbnailBytes);
                    else ClearModelPreviewImage();
                }
                // If the job hasn't changed, do nothing
            }
            else
            {
                // No current job, clear the image
                if (_ui.LastJobName != null)
                {
                    _ui.LastJobName = null;
                    ClearModelPreviewImage();
                }
            }
        }
        
        
        internal void ClearModelPreviewImage()
        {
            _ui.modelPreviewImg.BeginInvoke(new Action(() =>
            {
                _ui.modelPreviewImg.Image?.Dispose();
                _ui.modelPreviewImg.Image = null;
            }));
        }
        
        public void CheckFeatures()
        {
            if (!Compat.Is313OrAbove(_ui.PrinterClient.FirmVer))
            {
                _ui.AppendLog("This printer is running older firmware, some features may not be available, or work as intended. " +
                              "Please update to the latest firmware when possible for better compatibility");
                _ui.clearPlatformButton.Visible = false;
            }
            
            if (!_ui.PrinterClient.LedControl)
            {
                _ui.AppendLog("LEDs are not equipped or properly configured on this printer.");
                _ui.ledOffButton.Visible = false;
                _ui.ledOnButton.Visible = false;
            }

            if (_ui.PrinterClient.FiltrationControl) return;
            _ui.AppendLog("Filtration control is not available for this printer.");
            _ui.filtrationPanel.Visible = false;
            _ui.setChamberFanButton.Visible = false;
            _ui.chamberFanLabel.Visible = false;
        }
        
        
        
        public dynamic GetPrinterStatusJson()
        {

            return new
            {
                isPro = _ui.PrinterClient.IsPro,
                currentJob = _ui.currentJobLabel.Text,
                eta = _ui.etaLabel.Text,
                extruderTemp = _ui.extruderTempLabel.Text,
                bedTemp = _ui.bedTempLabel.Text,
                progress = _ui.progressLabel.Text,
                filamentUsed = _ui.totalFilamentLabel.Text,
                totalRunTime = _ui.totalRunTimeLabel.Text,
                printerStatus = _ui.printerStatusLabel.Text,
                layerInfo = _ui.layerLabel.Text,
                weight = _ui.weightLabel.Text,
                length = _ui.lengthLabel.Text,
                coolingFanSpeed = _ui.coolingFanLabel.Text,
                chamberFanSpeed = _ui.chamberFanLabel.Text,
                filtrationStatus = _ui.filterModeLabel.Text,
                firmwareVersion = _ui.PrinterClient.FirmwareVersion
            };
        }

        private GenericDialog MakeDialog(string windowTitle, string title, string text)
        {
            return new GenericDialog(windowTitle, title, text, _ui);
        }
        
        public void ShowDialog(string windowTitle, string title, string text, bool async)
        {
            var dialog = MakeDialog(windowTitle, title, text);
            // async is causing issues
            //if (async)
            //{
                // changed to Show to prevent the default sound 
                // might have unexpected side affects
            //    Task.Run(() =>
            //    {
            //        dialog.Show();
            //    });
            //}
            //else dialog.Show();
            dialog.Show();
        }
        
        
        // https://stackoverflow.com/questions/683330/how-to-make-a-window-always-stay-on-top-in-net
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")] 
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public void SetOnTop()
        {
            SetOnTop(_ui.Handle);
        }

        public void SetOnTop(IntPtr handle)
        {
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

    }
}