using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api;
using FlashForgeUI.ui.main.util;

namespace FlashForgeUI.ui.main.manager
{
    // todo full review and potential recode/rewrite
    // at least one long standing bug is still present , i think with resetting the state after the part is cooled?
    public class StatusTimerManager
    {
        private readonly MainMenu _ui;
        private readonly UiHelper _uiHelper;

        public StatusTimerManager(MainMenu form1)
        {
            _ui = form1;
            _uiHelper = new UiHelper(form1);
        }


        private int _statusUpdateFailures;
        private string _lastStatus;
        private bool _completionFlag;
        private bool _completionCooledFlag;

        private bool DiscordSyncEnabled()
        {
            return _ui.config.DiscordSync;
        }


        private async Task HandleStatusChange(FiveMClient.MachineInfo machineInfo, string status)
        {
            if (status.Equals("completed") && !_completionFlag)
            {
                if (DiscordSyncEnabled()) await _ui.webhook.SendMessage("Completed job: " + machineInfo.PrintFileName);
                _completionFlag = true;
                return;
            }
            _completionFlag = false; // reset flag
            if (DiscordSyncEnabled()) await _ui.webhook.SendMessage("Printer status update: " + machineInfo.Status);
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
                if (DiscordSyncEnabled()) await _ui.webhook.SendMessage("Ready for removal: " + machineInfo.PrintFileName);
                MessageBox.Show(machineInfo.PrintFileName + " ready for removal!", "Print Complete!");
            }
        }
        
        private async Task TickStatusChange(FiveMClient.MachineInfo machineInfo)
        {
            var statusChanged = _lastStatus == null || _lastStatus != machineInfo.Status;

            if (statusChanged)
            { // only on status change
                _lastStatus = machineInfo.Status;
                await HandleStatusChange(machineInfo, machineInfo.Status);
            }

            await CheckPartCool(machineInfo, machineInfo.Status);
        }
        
        private void SetActiveJobControls(bool active)
        {
            if (active)
            {
                _uiHelper.ShowJobRequiredControls();
                _uiHelper.HideJobInterferingControls();

            }
            else
            {
                _uiHelper.HideJobRequiredControls();
                _uiHelper.ShowJobInterferingControls();
            }
        }
        
        
        private void SetPrinting(FiveMClient.MachineInfo machineInfo)
        {
            _ui.etaLabel.Text = $"ETA: {machineInfo.CompletionTime.ToString("h:mm tt")} ({machineInfo.PrintEta})";
            _ui.currentJobLabel.Text = string.IsNullOrEmpty(machineInfo.PrintFileName)
                ? "Current Job: Error"
                : $"Current Job: {machineInfo.PrintFileName}";
            SetActiveJobControls(true);
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
            // todo this needs to be refactored to use MachineState
            switch (machineInfo.Status)
            {
                case "cancel":
                case "completed":
                    SetJobComplete(machineInfo); // update UI
                    SetActiveJobControls(true); // show controls hidden during printing (will prompt to clear the bed first if not)
                    //_ui.labelCurrentJob.Text = "Current Job: None";
                    break;
                case "ready":
                    SetActiveJobControls(false);
                    //_ui.labelCurrentJob.Text = "Current Job: None";
                    break;
                case "printing":
                    SetPrinting(machineInfo);
                    return;
                case "busy": 
                    SetActiveJobControls(true);
                    break;
            }
        }

        private void SetTemps(FiveMClient.MachineInfo machineInfo)
        {
            _ui.extruderTempLabel.Text =
                $"Extruder: {machineInfo.ExtruderTemp.AsStr()} / {machineInfo.ExtruderSetTemp.AsStr()}";
            //Console.WriteLine(_ui.extruderTempLabel.Text);
            _ui.bedTempLabel.Text =
                $"Bed: {machineInfo.PrintBedTemp.AsStr()} / {machineInfo.PrintBedSetTemp.AsStr()}";
        }

        private void SetGeneralInfo(FiveMClient.MachineInfo machineInfo)
        {
            _ui.totalFilamentLabel.Text = $"Filament used: {_ui.printerClient.LifetimeFilamentMeters}";
            //Console.WriteLine(_ui.totalFilamentLabel.Text);
            _ui.totalRunTimeLabel.Text = $"Run time: {_ui.printerClient.LifetimePrintTime}";
            _ui.printerStatusLabel.Text = $"Printer: {machineInfo.Status}";
            // removed because this is just in the firmware but does nothing (the printer doesn't know if the door is opened or closed)
            //_ui.doorStatusLabel.Text = machineInfo.DoorOpen ? "Door Status: Open" : "Door Status: Closed";
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
            if (_ui.poisonProgressBar1.InvokeRequired) _ui.poisonProgressBar1.Invoke(new Action(() => { _ui.poisonProgressBar1.Value = progress; }));
            else _ui.poisonProgressBar1.Value = progress;
        }

        private async Task SetModelPreview(FiveMClient.MachineInfo machineInfo)
        {
            if (machineInfo.IsPrinting() || machineInfo.IsJobComplete()) await _ui.UpdateModelPreview(machineInfo.PrintFileName);
            else _ui.ClearModelPreviewImage();
        }
        
        public async Task TickStatusUpdate()
        {
            var machineInfo = await _ui.printerClient.Info.Get();
            if (machineInfo != null)
            {
                _statusUpdateFailures--;
                await TickStatusChange(machineInfo); // status change
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