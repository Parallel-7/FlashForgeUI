using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api;
using FlashForgeUI.ui.main.dialog;
using FlashForgeUI.ui.main.util;

namespace FlashForgeUI.ui.main.manager
{
    // todo still needs this recode...
    // todo full review and potential recode/rewrite
    // at least one long standing bug is still present , i think with resetting the state after the part is cooled?
    public class StatusTimerManager
    {
        private readonly MainMenu _ui;
        private readonly UiHelper _uiHelper;

        public StatusTimerManager(MainMenu mainMenu)
        {
            _ui = mainMenu;
            _uiHelper = _ui.UiHelper;
        }


        private int _statusUpdateFailures;
        private string _lastStatus;
        private bool _completionFlag;
        private bool _completionCooledFlag;

        private bool DiscordSyncEnabled()
        {
            return _ui.Config.DiscordSync;
        }


        private async Task HandleStatusChange(FiveMClient.MachineInfo machineInfo, string status)
        {
            if (status.Equals("completed") && !_completionFlag)
            {
                if (DiscordSyncEnabled()) await _ui.Webhook.SendMessage("Completed job: " + machineInfo.PrintFileName);
                
                if (_ui.Config.VisualAlerts)
                {
                    new GenericDialog("Print Complete!", "Print completed",
                        machineInfo.PrintFileName + " has finished printing!", _ui).Show();
                }
                
                _completionFlag = true;
                return;
            }
            _completionFlag = false; // reset flag
            if (DiscordSyncEnabled()) await _ui.Webhook.SendMessage("Printer status update: " + machineInfo.Status);
        }

        private async Task CheckPartCool(FiveMClient.MachineInfo machineInfo, string status)
        {
            if (status != "completed")
            {
                _completionCooledFlag = false; // reset flag
                return; // not done
            }
            if (machineInfo.ExtruderTemp.AsDouble() <= 40 && !_completionCooledFlag)
            {
                _completionCooledFlag = true;
                if (DiscordSyncEnabled()) await _ui.Webhook.SendMessage("Ready for removal: " + machineInfo.PrintFileName);

                if (_ui.Config.VisualAlerts)
                {
                    new GenericDialog("Print Complete!", "Print ready for removal",
                        machineInfo.PrintFileName + " is ready for removal!", _ui).ShowDialog();
                }
                
                //MessageBox.Show(machineInfo.PrintFileName + " ready for removal!", "Print Complete!");
            }
        }
        
        private async Task CheckStatusChange(FiveMClient.MachineInfo machineInfo)
        {
            var statusChanged = _lastStatus == null || _lastStatus != machineInfo.Status;

            if (statusChanged)
            { // only on status change
                _lastStatus = machineInfo.Status;
                await HandleStatusChange(machineInfo, machineInfo.Status);
            }

            await CheckPartCool(machineInfo, machineInfo.Status);
        }
        
        private void SetPrintingInfo(FiveMClient.MachineInfo machineInfo)
        {
            _ui.etaLabel.Text = $"ETA: {machineInfo.CompletionTime.ToString("h:mm tt")} ({machineInfo.PrintEta})";
            _ui.currentJobLabel.Text = string.IsNullOrEmpty(machineInfo.PrintFileName)
                ? "Current Job: Error"
                : $"Current Job: {machineInfo.PrintFileName}";
        }

        private void SetJobComplete(FiveMClient.MachineInfo machineInfo)
        {
            _ui.etaLabel.Text = "ETA: Done";
            _ui.currentJobLabel.Text = string.IsNullOrEmpty(machineInfo.PrintFileName)
                ? "Current Job: Error"
                : $"Current Job: {machineInfo.PrintFileName}";
        }
        

        private void SetEtaAndJobControls(FiveMClient.MachineInfo machineInfo)
        {
            var state = machineInfo.MachineState;

            if (state == MachineState.Printing) SetPrintingInfo(machineInfo); 
            
            switch (state)
            {
                case MachineState.Busy:
                case MachineState.Calibrating:
                case MachineState.Error:
                case MachineState.Heating:
                case MachineState.Unknown:    
                    _uiHelper.HideJobRequiredControls();
                    _uiHelper.HideJobInterferingControls();
                    break;
                case MachineState.Paused:
                case MachineState.Pausing:
                case MachineState.Printing:
                    _uiHelper.HideJobInterferingControls();
                    _uiHelper.ShowJobRequiredControls();
                    break;
                case MachineState.Ready:
                    _uiHelper.ShowJobInterferingControls();
                    _uiHelper.HideJobRequiredControls();
                    break;
                case MachineState.Cancelled:
                case MachineState.Completed:
                    SetJobComplete(machineInfo);
                    _uiHelper.HideJobRequiredControls();
                    _uiHelper.ShowJobInterferingControls();
                    break;
            }
        }

        private void SetTemps(FiveMClient.MachineInfo machineInfo)
        {
            _ui.extruderTempLabel.Text = Utils.FormatTemps("Extruder: ", machineInfo.ExtruderTemp, machineInfo.ExtruderSetTemp);
            _ui.bedTempLabel.Text = Utils.FormatTemps("Bed: ", machineInfo.PrintBedTemp, machineInfo.PrintBedSetTemp);
        }

        private void SetGeneralInfo(FiveMClient.MachineInfo machineInfo)
        {
            Utils.SetLabelText(_ui.totalFilamentLabel, $"Filament used: {_ui.PrinterClient.LifetimeFilamentMeters}");
            Utils.SetLabelText(_ui.totalRunTimeLabel, $"Run time: {_ui.PrinterClient.LifetimePrintTime}");
            Utils.SetLabelText(_ui.printerStatusLabel, $"Printer: {machineInfo.Status}");
        }

        private void SetAdvancedInfo(FiveMClient.MachineInfo machineInfo)
        {
            _ui.nozzleSizeLabel.Text = $"Nozzle Size: {machineInfo.NozzleSize}";
            _ui.filamentTypeLabel.Text = machineInfo.IsPrinting() || machineInfo.IsJobComplete()
                ? $"Filament: {machineInfo.FilamentType}"
                : "Filament: --";
            _ui.tvocLabel.Text = $"TVOC Level: {machineInfo.Tvoc}";
            _ui.speedOffsetLabel.Text = $"Speed Offset: {machineInfo.PrintSpeedAdjust}";
            _ui.zAxisOffsetLabel.Text =
                $"Z-Axis Offset: {machineInfo.ZAxisCompensation.ToString("F3")}"; // trim excess 0s
        }

        private void SetFansAndFiltration(FiveMClient.MachineInfo machineInfo)
        {
            _ui.coolingFanLabel.Text = $"Cooling Fan: {machineInfo.CoolingFanSpeed}";
            _ui.chamberFanLabel.Text = $"Chamber Fan: {machineInfo.ChamberFanSpeed}";

            var filterMode = "None";
            if (machineInfo.ExternalFanOn) filterMode = "External";
            if (machineInfo.InternalFanOn) filterMode = "Internal";
            _ui.filterModeLabel.Text = $"Filtration: {filterMode}";
        }

        private void SetJobInfo(FiveMClient.MachineInfo machineInfo)
        {
            if (machineInfo.IsPrinting() || machineInfo.IsJobComplete() || machineInfo.IsPaused())
            {
                _ui.jobTimeLabel.Text = $"Job Time: {machineInfo.FormattedRunTime}";
                _ui.layerLabel.Text = $"Layer: {machineInfo.CurrentPrintLayer} / {machineInfo.TotalPrintLayers}";
                _ui.weightLabel.Text = $"Weight: {Convert.ToInt32(machineInfo.EstWeight)}g";
                _ui.lengthLabel.Text = $"Length: {Convert.ToInt32(machineInfo.EstLength)}m";
            }
            else
            {
                _ui.jobTimeLabel.Text = "Job Time: --:--:--";
                _ui.layerLabel.Text = "Layer: --";
                _ui.weightLabel.Text = "Weight: --";
                _ui.lengthLabel.Text = "Length: --";
            }
        }

        private void SetJobProgress(FiveMClient.MachineInfo machineInfo)
        {
            var progress = machineInfo.PrintProgressInt;
            _ui.progressLabel.Text = $"Progress: {progress}%";
            _ui.poisonProgressBar1.Invoke(new Action(() => { _ui.poisonProgressBar1.Value = progress; }));
        }

        private async Task SetModelPreview(FiveMClient.MachineInfo machineInfo)
        {
            if (machineInfo.IsPrinting() || machineInfo.IsJobComplete()) await _uiHelper.UpdateModelPreview(machineInfo.PrintFileName);
            else _uiHelper.ClearModelPreviewImage();
        }
        
        public async Task TickStatusUpdate()
        {
            var machineInfo = await _ui.PrinterClient.Info.Get();
            if (machineInfo != null)
            {
                _statusUpdateFailures--;
                await CheckStatusChange(machineInfo); // status change
                SetEtaAndJobControls(machineInfo);
                SetTemps(machineInfo);
                SetGeneralInfo(machineInfo);
                SetAdvancedInfo(machineInfo);
                SetJobInfo(machineInfo);
                SetFansAndFiltration(machineInfo);
                SetJobProgress(machineInfo);
                await SetModelPreview(machineInfo);
            }
            else
            {
                _statusUpdateFailures++;
                if (_statusUpdateFailures > 0)
                {
                    // increase update timeout based on failures
                    _ui.timerStatusUpdate.Interval += 1000 * _statusUpdateFailures;
                    Debug.WriteLine($"Status update failed , timeout increase to {_ui.timerStatusUpdate.Interval}");
                }

                if (_statusUpdateFailures < 3) return;
                _uiHelper.HandleLostConnection();
            }
        }
    }
}