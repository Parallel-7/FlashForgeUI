using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeUI.ui.main.util;
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
            
            await _ui.CmdWait();
            var form = new TempControlWindow(_ui, "extruder");
            await Utils.WaitForForm(form);
            _ui.CmdRelease();
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

            await _ui.CmdWait();
            var form = new TempControlWindow(_ui, "platform");
            await Utils.WaitForForm(form);
            _ui.CmdRelease();
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