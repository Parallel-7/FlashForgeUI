using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FiveMApi.api;

namespace FlashForgeUI.webui
{
    public class WebServerBridge
    {
        // "Bridge" between the desktop ui and the web ui for control, etc.
        private readonly FiveMClient _client;

        public WebServerBridge(FiveMClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Pauses the current print job.
        /// </summary>
        public async Task<string> PauseJob()
        {
            if (!await _client.Info.IsPrinting()) return "No active job.";
            if (!await _client.JobControl.PausePrintJob()) return "Error pausing job.";
            return "Job paused.";
        }

        /// <summary>
        /// Resumes the paused print job.
        /// </summary>
        public async Task<string> ResumeJob()
        {
            if (!await _client.JobControl.ResumePrintJob()) return "Error resuming job.";
            return "Job resumed.";
        }

        /// <summary>
        /// Stops the current print job.
        /// </summary>
        public async Task<string> StopJob()
        {
            if (!await _client.Info.IsPrinting()) return "No active job.";
            if (!await _client.JobControl.CancelPrintJob()) return "Error stopping job.";
            return "Job stopped.";
        }

        /// <summary>
        /// Turns the printer's LED light on.
        /// </summary>
        public async Task<string> SetLedOn()
        {
            await _client.Control.SetLedOn();
            return "LED turned on.";
        }

        /// <summary>
        /// Turns the printer's LED light off.
        /// </summary>
        public async Task<string> SetLedOff()
        {
            await _client.Control.SetLedOff();
            return "LED turned off.";
        }

        /// <summary>
        /// Homes the printer's axes.
        /// </summary>
        public async Task<string> HomeAxes()
        {
            var info = await _client.Info.Get();
            if (info.DoorOpen) return "Cannot home axes: printer door is open.";

            if (info.Status != "ready") return $"Cannot home axes: printer status is '{info.Status}'.";
            var homed = await _client.Control.HomeAxes();
            return homed ? "Axes homed." : "Error homing axes.";

        }

        /// <summary>
        /// Sets the cooling fan speed (0-100%).
        /// </summary>
        public async Task<string> SetCoolingFanSpeed(int speed)
        {
            if (speed < 0 || speed > 100) return "Invalid speed. Must be between 0 and 100.";
            await _client.Control.SetCoolingFanSpeed(speed);
            return $"Cooling fan speed set to {speed}%.";
        }

        /// <summary>
        /// Sets the chamber fan speed (0-100%).
        /// </summary>
        public async Task<string> SetChamberFanSpeed(int speed)
        {
            if (speed < 0 || speed > 100) return "Invalid speed. Must be between 0 and 100.";
            await _client.Control.SetChamberFanSpeed(speed);
            return $"Chamber fan speed set to {speed}%.";
        }

        /// <summary>
        /// Sets the bed temperature (0-100°C).
        /// </summary>
        public async Task<string> SetBedTemperature(int temp)
        {
            if (temp < 0 || temp > 100) return "Invalid temperature. Must be between 0 and 100°C.";
            var result = await _client.TempControl.SetBedTemp(temp);
            return result ? $"Bed temperature set to {temp}°C." : "Error setting bed temperature.";
        }

        /// <summary>
        /// Sets the extruder temperature (0-280°C).
        /// </summary>
        public async Task<string> SetExtruderTemperature(int temp)
        {
            if (temp < 0 || temp > 280) return "Invalid temperature. Must be between 0 and 280°C.";
            var result = await _client.TempControl.SetExtruderTemp(temp);
            return result ? $"Extruder temperature set to {temp}°C." : "Error setting extruder temperature.";
        }

        /// <summary>
        /// Turns off bed heating.
        /// </summary>
        public async Task<string> CancelBedHeating()
        {
            var result = await _client.TempControl.CancelBedTemp();
            return result ? "Bed heating cancelled." : "Error cancelling bed heating.";
        }

        /// <summary>
        /// Turns off extruder heating.
        /// </summary>
        public async Task<string> CancelExtruderHeating()
        {
            var result = await _client.TempControl.CancelExtruderTemp();
            return result ? "Extruder heating cancelled." : "Error cancelling extruder heating.";
        }

        /// <summary>
        /// Sets the Z-axis offset.
        /// </summary>
        public async Task<string> SetZAxisOffset(float offset)
        {
            var result = await _client.Control.SetZAxisOverride(offset);
            return result ? $"Z-axis offset set to {offset} mm." : "Error setting Z-axis offset.";
        }

        /// <summary>
        /// Starts a local print job.
        /// </summary>
        /// <param name="fileName">Name of the G-code file on the printer.</param>
        /// <param name="autoLevel">Whether to perform auto-leveling.</param>
        public async Task<string> StartLocalJob(string fileName, bool autoLevel = false)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return "Invalid file name.";

            var info = await _client.Info.Get();
            if (info.DoorOpen) return "Cannot start job: printer door is open.";

            if (info.Status != "ready") return $"Cannot start job: printer status is '{info.Status}'.";

            var result = await _client.JobControl.PrintLocalFile(fileName, autoLevel);
            return result ? $"Started job '{fileName}'." : $"Error starting job '{fileName}'.";
        }

        /// <summary>
        /// Uploads and starts a new print job.
        /// </summary>
        /// <param name="filePath">Path to the G-code file.</param>
        /// <param name="startNow">Whether to start the job immediately after upload.</param>
        /// <param name="autoLevel">Whether to perform auto-leveling.</param>
        public async Task<string> UploadAndStartJob(string filePath, bool startNow = true, bool autoLevel = false)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) return "Invalid file path.";

            var info = await _client.Info.Get();
            if (info.DoorOpen) return "Cannot start job: printer door is open.";

            if (info.Status != "ready") return $"Cannot start job: printer status is '{info.Status}'.";

            var result = await _client.JobControl.UploadFile(filePath, startNow, autoLevel);
            return result ? $"Uploaded and started job '{Path.GetFileName(filePath)}'." : "Error uploading or starting job.";
        }
        
        public async Task<List<string>> GetGCodeFileList(string listType)
        {
            List<string> files;
            if (listType == "local") files = await _client.Files.GetLocalFileList();
            else files = await _client.Files.GetRecentFileList();
            return files;
        }

        public async Task<byte[]> GetGCodeThumbnail(string filename)
        {
            // Retrieve the thumbnail image data for the specified G-code file
            var thumbnailData = await _client.Files.GetGCodeThumbnail(filename);
            return thumbnailData;
        }

        /// <summary>
        /// Turns on external filtration.
        /// </summary>
        public async Task<string> SetExternalFiltrationOn()
        {
            var reset = await _client.Control.SetFiltrationOff();
            if (!reset) return "Error resetting filtration status.";

            var result = await _client.Control.SetExternalFiltrationOn();
            return result ? "External filtration turned on." : "Error turning on external filtration.";
        }

        /// <summary>
        /// Turns on internal filtration.
        /// </summary>
        public async Task<string> SetInternalFiltrationOn()
        {
            var reset = await _client.Control.SetFiltrationOff();
            if (!reset) return "Error resetting filtration status.";

            var result = await _client.Control.SetInternalFiltrationOn();
            return result ? "Internal filtration turned on." : "Error turning on internal filtration.";
        }

        /// <summary>
        /// Turns off filtration.
        /// </summary>
        public async Task<string> SetFiltrationOff()
        {
            var result = await _client.Control.SetFiltrationOff();
            return result ? "Filtration turned off." : "Error turning off filtration.";
        }

        /// <summary>
        /// Checks if the printer is ready for a new job.
        /// </summary>
        public async Task<string> CheckPrinterReady()
        {
            var info = await _client.Info.Get();
            if (info.DoorOpen) return "Printer door is open.";

            switch (info.Status)
            {
                case "ready":
                    return "Printer is ready.";
                case "busy":
                    return "Printer is busy; please clear the cancelled print job.";
                case "printing":
                    return "Printer is currently printing.";
                case "completed":
                    return "Print bed is occupied; please clear it.";
                default:
                    return $"Printer status is '{info.Status}'.";
            }
        }
        
        /// <summary>
        /// Checks if the printer is currently printing :p
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsPrinting()
        {
            var info = await _client.Info.Get();
            return info.IsPrinting();
        }

        public async Task<bool> IsReady()
        {
            var info = await _client.Info.Get();
            return info.IsReady();
        }

        public async Task<bool> IsBusy()
        {
            var info = await _client.Info.Get();
            return info.IsBusy();
        }
    }
}
