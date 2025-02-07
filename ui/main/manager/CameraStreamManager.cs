using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeUI.ui.main.util;

namespace FlashForgeUI.ui.main.manager
{
    public class CameraStreamManager
    {
        
        private readonly MainMenu _ui;
        private string _streamUrl;

        private MjpegClient _mjpegClient;

        public CameraStreamManager(MainMenu mainMenu)
        {
            _ui = mainMenu;
            _mjpegClient = new MjpegClient();
        }
        

        public bool Start()
        {
            _streamUrl = _ui.config.CustomCamera ? _ui.config.CustomCameraUrl.Replace("{IpAddress}", _ui.printerClient.IpAddress) : $"http://{_ui.printerClient.IpAddress}:8080/?action=stream";
            _mjpegClient.Start(_streamUrl);
            _mjpegClient.FrameReceived += HandleFrame;
            _mjpegClient.StreamError += HandleError;
            return true;
        }

        public void Stop()
        {
            _mjpegClient.FrameReceived -= HandleFrame;
            _mjpegClient.StreamError -= HandleError;
            _mjpegClient.Stop();
            ResetPreview();
        }

        private void ResetPreview()
        {
            _ui.webcamPictureBox.Image?.Dispose();
            _ui.webcamPictureBox.Image = null;
        }

        private void HandleError(object sender, string message)
        {
            _ui.AppendLog("MJPEG Stream error: " + message);
            Stop();
            _ui.ButtonManager.PreviewOff();
        }

        private void HandleFrame(object sender, Bitmap frame)
        {
            _lastStreamFrame = frame;
            if (_ui.webcamPictureBox.InvokeRequired)
            {
                _ui.webcamPictureBox.BeginInvoke(new MethodInvoker(() =>
                {
                    _ui.webcamPictureBox.Image?.Dispose();
                    _ui.webcamPictureBox.Image = frame;
                }));
            }
            else
            {
                _ui.webcamPictureBox.Image?.Dispose();
                _ui.webcamPictureBox.Image = frame;
            }
        }
        
        
        private Bitmap _lastStreamFrame;
        public async Task<Bitmap> GetSingleFrameAsync()
        {
            _lastStreamFrame = null; // doing this prevents sending a garbled frame...
            while (_lastStreamFrame == null) await Task.Delay(100);
            var frame = _lastStreamFrame;
            return frame;
        }

    }
}