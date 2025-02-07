using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api;
using Microsoft.VisualBasic;

namespace FlashForgeUI.ui.main.manager
{
    public class ConnectionManager
    {

        private readonly MainMenu _ui;
        
        public ConnectionManager(MainMenu form1)
        {
            _ui = form1;
        }
        
        private async Task<bool> ConnectLastUsedPrinter(IEnumerable<FlashForgePrinter> printers)
        {
            var lastPrinter = PrinterDetails.Load(); // check for saved printer
            if (lastPrinter == null) return false;
            
            var matchingPrinter = printers.FirstOrDefault(p => p.SerialNumber.Equals(lastPrinter.SerialNumber)); // match it in the list of online printers
            
            if (matchingPrinter == null)
            { // sometimes the printer can be online but not answer the discovery broadcast, prompt the user for manual connection
                var result = MessageBox.Show(
                    "Unable to find last used printer, try to manually connect (with the IP Address?)",
                    "Last used printer not found",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.OK) return false; // said no to manual connection
                
                var ip = Interaction.InputBox( // manual connection
                    "Enter printer IP",
                    "Manual Printer Connection"
                );
                if (!string.IsNullOrEmpty(ip)) return await ConnectAndSave(ip, lastPrinter.SerialNumber, lastPrinter.CheckCode, lastPrinter.Name);
                MessageBox.Show("Invalid IP Address entered", "Cancelled");
                return false;
            }

            try
            { // last used printer is online, attempt connection
                
                _ui.PrinterClient = new FiveMClient(matchingPrinter.IPAddress.ToString(), matchingPrinter.SerialNumber,
                    lastPrinter.CheckCode);
                if (await _ui.PrinterClient.InitControl()) // control OK
                {
                    return true;
                }
                else
                {
                    // control failed
                    MessageBox.Show($"Unable to communicate used printer ({matchingPrinter.Name})",
                        $"Communication error (control failed)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            { // connection failed
                MessageBox.Show($"Error connecting to the last used printer: {ex.Message}", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private async Task<bool> ConnectAndSave(string ipAddress, string serialNumber, string checkCode, string printerName)
        {
            if (string.IsNullOrEmpty(ipAddress) 
                || string.IsNullOrEmpty(serialNumber) 
                || string.IsNullOrEmpty(checkCode) 
                || string.IsNullOrEmpty(printerName))
                return false;
            try
            {
                _ui.PrinterClient = new FiveMClient(ipAddress, serialNumber, checkCode);
                if (await _ui.PrinterClient.InitControl()) // control OK
                {
                    // cache new printer 
                    new PrinterDetails(_ui.PrinterClient.PrinterName, ipAddress, serialNumber, checkCode).Save();
                    return true;
                }

                // control failed
                MessageBox.Show($"Unable to communicate with {printerName}",
                    $"Communication error (control failed)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect to {printerName} : {ex.Message}", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
        
        private async Task<bool> ConnectAndSave(FlashForgePrinter printer, string checkCode)
        {
            return await ConnectAndSave(printer.IPAddress.ToString(), printer.SerialNumber, checkCode, printer.Name);
        }
        
        private async Task<bool> ConnectNewPrinter(IEnumerable<FlashForgePrinter> printers)
        {
            using (var selectionMenu = new PrinterSelectionWindow(_ui, printers.ToList()))
            {
                var result = selectionMenu.ShowDialog();
                if (result == DialogResult.OK) if (await ConnectAndSave(selectionMenu.SelectedPrinter, selectionMenu.CheckCode)) return true;
            }
            MessageBox.Show("No printer was selected or check code was not entered.", "Operation Cancelled",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private async Task<List<FlashForgePrinter>> ScanForPrinters()
        {
            _ui.AppendLog("Scanning for FlashForge printers");
            var discovery = new FlashForgePrinterDiscovery();
            //var sw = new Stopwatch();
            //sw.Start();
            var printers = await discovery.DiscoverPrintersAsync();
            //sw.Stop();
            //Console.WriteLine($"Printer Discovery took {sw.ElapsedMilliseconds}ms");
            _ui.AppendLog(printers.Count == 1 ? $"{printers.Count} printer found." : $"{printers.Count} printers found.");
            return printers;
        }
        
        
        public async Task<bool> FindPrinterAndConnect()
        {
            var printers = await ScanForPrinters();
            if (printers.Count == 0)
            {
                // No printers found
                MessageBox.Show("No FlashForge printers found. Make sure LAN-only mode is enabled.",
                    "No Printers Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (await ConnectLastUsedPrinter(printers)) return true;
            return await ConnectNewPrinter(printers);
        }
    }
}