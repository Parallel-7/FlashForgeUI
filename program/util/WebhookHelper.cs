using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Discord.Webhook;
using Discord.Webhook.Exceptions;
using FiveMApi.api;
using FlashForgeUI.ui.main;

namespace FlashForgeUI.program.util
{
    public class WebhookHelper
    {
        private readonly string _webhookUrl;
        private readonly MainMenu mainMenu;

        public WebhookHelper(string url, MainMenu mainMenu)
        {
            _webhookUrl = url;
            this.mainMenu = mainMenu;
        }

        private async Task<bool> Execute(WebhookObject hook)
        {
            try
            {
                await new Webhook(_webhookUrl).SendAsync(hook);
                return true;
            }
            catch (DiscordWebhookException ex)
            {
                Debug.WriteLine("WebhookHelper.SendMessage exception: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> SendMessage(string message, DColor color = null)
        {
            if (color == null) color = Colors.Green; // set default color if not set
            var webhook = new WebhookObject();
            webhook.AddEmbed(builder =>
            {
                builder.WithTitle("FlashForgeUI")
                    .WithDescription(message)
                    .WithColor(color);
            });
            return await Execute(webhook);
        }

        public async Task<bool> SendWarningMessage(string message)
        {
            return await SendMessage(message, Colors.Yellow);
        }

        public async Task<bool> SendErrorMessage(string message)
        {
            return await SendMessage(message, Colors.Red);
        }

        public async Task<bool> SendStatus(FiveMClient printerClient)
        {
            Debug.WriteLine("WebhookHelper.SendStatus()");
            var embed = await CreatePrinterStatusEmbed(printerClient);
            if (embed == null) return false;
            var hook = new WebhookObject();
            hook.AddEmbed(embed);
            return await Execute(hook);
        }

        private async Task<Embed> CreatePrinterStatusEmbed(FiveMClient printerClient)
        {
            var machineInfo = await printerClient.Info.Get();
            if (machineInfo == null)
            {
                Debug.WriteLine("CreatePrinterStatusEmbed error, printerClient.Info.Get() returned null");
                return null;
            }

            if (machineInfo.IsPaused() || machineInfo.IsBusy() || machineInfo.IsReady()) return null; // no point in sending updates in these states

            var embed = new EmbedBuilder().WithTitle(printerClient.PrinterName + " status").WithColor(Colors.Orange);

            var img = await mainMenu.GetMjpegStreamManager().GetSingleFrameAsync();
            

            var webcamPreview = await ImgBB.Upload(img, "preview.png");
            if (webcamPreview != null) embed.WithImage(webcamPreview);
            else Debug.WriteLine("CreatePrinterStatusEmbed failed to get webcam image");

            // Current Job Section
            var currentJob = string.IsNullOrEmpty(machineInfo.PrintFileName) ? "Error" : machineInfo.PrintFileName;
            embed.AddField("Current Job", currentJob)
                .AddField("Job Progress", $"{machineInfo.PrintProgressInt}%", false);

            // Printer Status Section
            embed.AddField("Printer Status", machineInfo.Status, true)
                .AddField("Door Status", machineInfo.DoorOpen ? "Open" : "Closed", true);

            // Total Run Time & Total Filament Used Section
            embed.AddField("Total Run Time", printerClient.LifetimePrintTime, true)
                .AddField("Total Filament Used", printerClient.LifetimeFilamentMeters, true);
            
            // Job Information Section with adjusted spacing for Length and Weight
            if (machineInfo.IsPrinting() || machineInfo.IsJobComplete())
            {
                
                embed.AddField("Job Information",
                        $"Layer: {machineInfo.CurrentPrintLayer} / {machineInfo.TotalPrintLayers}\nETA: {machineInfo.PrintEta}\nJob Time: {machineInfo.FormattedRunTime}",
                        false)
                    .AddField("Length", $"{Convert.ToInt32(machineInfo.EstLength)}m", true)
                    .AddField("Weight", $"{Convert.ToInt32(machineInfo.EstWeight)}g", true);
            }
            else
            {
                embed.AddField("Job Information", "Layer: --\nETA: --:--:--\nJob Time: --:--:--", false)
                    .AddField("Length", "--m", true)
                    .AddField("Weight", "--g", true);
            }
            
            

            // Temperatures Section
            embed.AddField("Temperatures",
                $"Bed: {Convert.ToInt32(machineInfo.PrintBedTemp)} / {Convert.ToInt32(machineInfo.PrintBedSetTemp)}C\n" +
                $"Extruder: {Convert.ToInt32(machineInfo.ExtruderTemp)} / {Convert.ToInt32(machineInfo.ExtruderSetTemp)}C",
                false);

            // Printer Offsets Section
            embed.AddField("Printer Offsets",
                $"Speed Offset: {machineInfo.PrintSpeedAdjust}\nZ-Axis Offset: {machineInfo.ZAxisCompensation:F3}",
                true);

            // Fans and Filtration Control Section
            embed.AddField("Fans",
                    $"Cooling Fan: {machineInfo.CoolingFanSpeed}\nChamber Fan: {machineInfo.ChamberFanSpeed}", true)
                .AddField("Filtration",
                    $"TVOC Level: {machineInfo.Tvoc}\nFiltration: {(machineInfo.ExternalFanOn ? "External" : machineInfo.InternalFanOn ? "Internal" : "None")}",
                    true);

            // Filament and Nozzle Info Section
            var filamentType = machineInfo.IsPrinting() || machineInfo.IsJobComplete()
                ? machineInfo.FilamentType
                : "--";
            embed.AddField("Filament Type", filamentType, true)
                .AddField("Nozzle Size", machineInfo.NozzleSize, true);

            return embed.Build();
        }
    }
}    