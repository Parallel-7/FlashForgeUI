using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api;
using FlashForgeUI.ui.main.util;
using Microsoft.VisualBasic;

namespace FlashForgeUI.manager
{
    public class ButtonManager
    {

        private readonly ui.main.MainMenu _ui;

        public ButtonManager(ui.main.MainMenu form1)
        {
            _ui = form1;
        }

        // LEDs
        public async Task LedOn()
        {
            await _ui.printerClient.Control.SetLedOn();
            _ui.AppendLog("LED turned on.");
        }

        public async Task LedOff()
        {
            await _ui.printerClient.Control.SetLedOff();
            _ui.AppendLog("LED turned off.");
        }
        

        public void TogglePreview()
        {
            if (_ui.printerClient == null) return;
            if (!_ui.printerClient.IsPro)
            { // make sure there's actually a webcam
                MessageBox.Show("No webcam!",
                    "The regular 5M has no built-in webcam. If you've installed one yourself, you can disable this check in settings");
                return;
            }
            if (!_ui.WebcamOn)
            {
                _ui.StreamManager.Start();
                _ui.toggleWebcamButton.Text = "Preview Off";
                _ui.WebcamOn = true;
            }
            else
            {
                _ui.StreamManager.Stop();
                _ui.toggleWebcamButton.Text = "Preview On";
                _ui.WebcamOn = false;
            }
        }

        // Filtration
        public async Task FilteringOff()
        {
            // todo this needs to be coded into the webUI, this is a lazy fix for now since it will invoke this (indirectly) anyways
            if (!_ui.printerClient.IsPro)
            {
                _ui.AppendLog("Not equipped with filtration.");
                return;
            }
            await _ui.printerClient.Control.SetFiltrationOff();
            _ui.AppendLog("Filtration turned off.");
        }
        
        public async Task ExternalFilterOn()
        {
            // todo same for here
            if (!_ui.printerClient.IsPro)
            {
                _ui.AppendLog("Not equipped with filtration.");
                return;
            }
            await _ui.CmdWait();
            if (!await _ui.printerClient.Control.SetFiltrationOff()) _ui.AppendLog("(Error) Unable to reset filtration status");
            if (!await _ui.printerClient.Control.SetExternalFiltrationOn()) _ui.AppendLog("(Error) Unable to start external filtration");
            else _ui.AppendLog("External filtration turned on.");
            _ui.CmdRelease();
        }

        public async Task InternalFilterOn()
        {
            // todo also same for here
            if (!_ui.printerClient.IsPro)
            {
                _ui.AppendLog("Not equipped with filtration.");
                return;
            }
            await _ui.CmdWait();
            if (!await _ui.printerClient.Control.SetFiltrationOff()) _ui.AppendLog("(Error) Unable to reset filtration status");
            if (!await _ui.printerClient.Control.SetInternalFiltrationOn()) _ui.AppendLog("(Error) Unable to start internal filtration");
            else _ui.AppendLog("Internal filtration turned on");
            _ui.CmdRelease();
        }
        
        // Fans
        public async Task SetCoolingFanSpeed()
        {
            var input = Interaction.InputBox("Fan speed (0-100)", "Set Cooling Fan Speed", "0");
            if (int.TryParse(input, out var speed)) await _ui.printerClient.Control.SetCoolingFanSpeed(speed);
            else _ui.AppendLog("Setting cooling fan speed cancelled.");
        }
        
        public async Task SetChamberFanSpeed()
        {
            // todo this also needs to be coded into the web ui
            if (!_ui.printerClient.IsPro)
            {
                _ui.AppendLog("Not equipped with chamber fan.");
                return;
            }
            var input = Interaction.InputBox("Fan speed (0-100)", "Set Chamber Fan Speed", "0");
            if (int.TryParse(input, out var speed)) await _ui.printerClient.Control.SetChamberFanSpeed(speed);
            else _ui.AppendLog("Setting cooling fan speed cancelled.");
        }
        
        // Job Control

        public async Task PauseJob()
        {
            await _ui.CmdWait();
            if (!await _ui.printerClient.Info.IsPrinting()) _ui.AppendLog("No job to pause...");
            else if (!await _ui.printerClient.JobControl.PausePrintJob()) _ui.AppendLog("(Error) Unable to pause current job");
            else _ui.AppendLog("Job paused.");
            _ui.CmdRelease();
        }

        public async Task ResumeJob()
        {
            await _ui.CmdWait();
            // need to see what "state" is when paused, could be exactly that lol
            if (!await _ui.printerClient.JobControl.ResumePrintJob()) _ui.AppendLog("(Error) Unable to resume current job");
            else _ui.AppendLog("Job resumed.");
            _ui.CmdRelease();
        }

        public async Task StopJob()
        {
            await _ui.CmdWait();
            if (!await _ui.printerClient.Info.IsPrinting()) _ui.AppendLog("No job to stop...");
            else if (!await _ui.printerClient.JobControl.CancelPrintJob()) _ui.AppendLog("(Error) Unable to cancel current job");
            else _ui.AppendLog("Job cancelled.");
            _ui.CmdRelease();
        }

        public async Task ClearPlatform()
        {
            if (!Compat.Is313OrAbove(_ui.printerClient.FirmVer)) return; // not supported below fw 3.13.3
            await _ui.CmdWait();
            var state = await _ui.printerClient.Info.GetState();
            if (state != MachineState.Cancelled && state != MachineState.Completed) _ui.AppendLog("Nothing to clear...");
            else if (!await _ui.printerClient.JobControl.ClearPlatform()) _ui.AppendLog("Unable to clear printing state.");
            else
            {
                _ui.AppendLog(state == MachineState.Cancelled
                    ? "Cleared cancelled job state."
                    : "Cleared completed job state.");
            }
            _ui.CmdRelease();
        }
        
        
        // Upload (and start) job/start local/recent (last 10) jobs
        public async Task<bool> SelectAndUploadGCodeFile()
        {
            using (var form = new GCodeFilePicker())
            {
                // todo this needs to be tested (the ReaLTaiizor refactor)
                // show local g-code file picker
                if (form.ShowDialog() != DialogResult.OK) return false; // cancelled by user
                var filePath = form.SelectedFilePath;
                var startNow = form.StartNow;
                var autoLevel = form.AutoLevel;

                _ui.AppendLog(startNow
                    ? $"Uploading and starting job {filePath} (Auto level: {autoLevel}"
                    : $"Uploading job file {filePath}");

                var ok = await _ui.printerClient.JobControl.UploadFile(filePath, startNow, autoLevel);
                if (!ok) _ui.AppendLog($"Uploading job failed.");
                return ok;
            }
        }
        
        public async Task SelectRecentJob()
        {
            var localFileList = new GCodeListWindow(_ui.printerClient); // get recent (last 10 files) list
            var result = localFileList.ShowDialog();
            localFileList.Dispose();
            if (result == DialogResult.OK) await StartLocalJob(localFileList);
            else _ui.AppendLog("Recent job selection cancelled.");
        }

        public async Task SelectLocalJob()
        {
            var localFileList = new GCodeListWindow(_ui.printerClient, true); // get full list
            var result = localFileList.ShowDialog();
            localFileList.Dispose();
            if (result == DialogResult.OK) await StartLocalJob(localFileList);
            else _ui.AppendLog("Local job selection cancelled.");
        }
        
        private async Task StartLocalJob(GCodeListWindow localFileListWindow)
        { // get selected file from list and start the print
            if (await _ui.printerClient.JobControl.PrintLocalFile(localFileListWindow.SelectedFileName,
                    localFileListWindow.AutoLevel))
            {
                _ui.AppendLog($"Starting job {localFileListWindow.SelectedFileName}");
            }
            else _ui.AppendLog($"Error starting recent job {localFileListWindow.SelectedFileName}");
        }
        
    }
}