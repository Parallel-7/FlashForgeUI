using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FlashForgeUI.ui.main.manager
{
    public class InteractionManager
    {
        private readonly MainMenu _ui;

        public InteractionManager(MainMenu mainMenu)
        {
            _ui = mainMenu;
        }


        public async Task HandleHomeAxes()
        {
            if (!await _ui.CheckJobReady()) return;
            if (await _ui.CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            await _ui.CmdWait();
            _ui.AppendLog("Homing axes");
            var homed = await _ui.PrinterClient.Control.HomeAxes();
            _ui.AppendLog(homed ? "Homed." : "Error homing axes.");
            _ui.CmdRelease();
        }
        
        
        public async Task HandleSetExtruderTemp()
        {
            if (await _ui.CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }
            
            // todo use new TempControlWindow
            var input = Interaction.InputBox("Extruder temp (max 280)", "Set Extruder Temperature", "0");
            if (int.TryParse(input, out var temp))
            {
                if (temp > 280) MessageBox.Show("Cannot set above 280C!");
                else
                {
                    await _ui.CmdWait();
                    if (await _ui.PrinterClient.TempControl.SetExtruderTemp(temp)) _ui.AppendLog($"Extruder temp set to {temp}C");
                    else _ui.AppendLog("Unable to set extruder temp!!");
                    _ui.CmdRelease();
                }
            }
            else
            {
                MessageBox.Show("Invalid input.", "Cancelled");
            }
        }

        public async Task HandleCancelExtruderTemp()
        {
            if (await _ui.CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            await _ui.CmdWait();
            if (!await _ui.PrinterClient.TempControl.CancelExtruderTemp()) _ui.AppendLog("Unable to turn off extruder heat!!");
            else _ui.AppendLog("Extruder heating disabled.");
            _ui.CmdRelease();
        }

        public async Task HandleSetBedTemp()
        {
            if (await _ui.CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }
            
            // todo use new temp control window
            var input = Interaction.InputBox("Bed temp (max 100)", "Set Bed Temperature", "0");
            if (int.TryParse(input, out var temp))
            {
                if (temp > 100) MessageBox.Show("Cannot set above 100C!");
                else
                {
                    await _ui.CmdWait();
                    if (await _ui.PrinterClient.TempControl.SetBedTemp(temp)) _ui.AppendLog($"Bed temp set to {temp}C");
                    else _ui.AppendLog("Unable to set bed temp!!");
                    _ui.CmdRelease();
                }
            }
            else
            {
                MessageBox.Show("Invalid input.", "Cancelled");
            }
        }

        public async Task HandleCancelBedTemp()
        {
            if (await _ui.CmdBusy())
            {
                MessageBox.Show("Printer is busy.");
                return;
            }

            await _ui.CmdWait();
            if (!await _ui.PrinterClient.TempControl.CancelBedTemp()) _ui.AppendLog("Unable to turn off bed heating!!");
            else _ui.AppendLog("Bed heating disabled.");
            _ui.CmdRelease();
        }


    }
}