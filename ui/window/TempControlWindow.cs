using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api.misc;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class TempControlWindow : Form
    {
        
        // todo set and cancel button click handlers
        
        
        private MainMenu _ui;
        private readonly string _mode;

        private CancellationTokenSource _cts;
        private CancellationToken _ct;
        
        public TempControlWindow(MainMenu mainMenu, string mode)
        {
            InitializeComponent();
            _ui = mainMenu;
            _mode = mode;

            Shown += (s, e) =>
            {
                if (_ui.Config.AlwaysOnTop) _ui.UiHelper.SetOnTop(Handle);
                if (_ui.Config.AudioAlerts) SystemSounds.Exclamation.Play();
                Init();
            };
            
            FormClosing += (s, e) => 
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                
                _cts.Cancel();
            };
        }

        private void Init()
        {
            if (_mode.Equals("platform")) headerLabel.Text = "Platform";
            else headerLabel.Text = "Extruder";


            _cts = new CancellationTokenSource();
            _ct = _cts.Token;
            UpdateTempLoop();
        }

        
        private void UpdateTempLoop()
        {
            Task.Run(async () =>
            {
                while (!_ct.IsCancellationRequested)
                {
                    
                    var i = await _ui.PrinterClient.Info.Get();
                    
                    if (_mode.Equals("platform"))
                    {
                        var pb = i.PrintBedTemp;
                        var pbs = i.PrintBedSetTemp;

                        tempLabel.Text = $"Current: {pb}/{pbs}";
                    }
                    else
                    {
                        var ex = i.ExtruderTemp;
                        var exs = i.ExtruderSetTemp;

                        tempLabel.Text = $"Current: {ex}/{exs}";
                    }

                    await Task.Delay(2000, _ct);

                }
            });
        }
    }
}