﻿using System;
using System.Runtime.InteropServices;
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