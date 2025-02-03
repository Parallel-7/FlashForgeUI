using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;

namespace FlashForgeUI.ui.main.manager
{
    public class MjpegStreamManager
    {

        private readonly MainMenu _ui;

        public MjpegStreamManager(MainMenu form1)
        {
            _ui = form1;
        }
        
        public void Start()
        {
            if (_ui.config.CustomCamera) // check for custom camera url
            {
                // allow users to use placeholders for the IP
                var url = _ui.config.CustomCameraUrl.Replace("{IpAddress}", _ui.printerClient.IpAddress);
                _ui.mjpegStream = new MJPEGStream(url);
                Console.WriteLine("Using custom camera url: " + url);
            }
            else _ui.mjpegStream = new MJPEGStream($"http://{_ui.printerClient.IpAddress}:8080/?action=stream"); // default for the 5M pro
            _ui.mjpegStream.NewFrame += MJPEGStream_NewFrame;
            _ui.mjpegStream.VideoSourceError += MJPEGStream_VideoSourceError;
            _ui.mjpegStream.Start();
        }

        public bool IsRunning()
        {
            return _ui.mjpegStream != null && _ui.mjpegStream.IsRunning;
        }
        
        public void Stop()
        {
            if (IsRunning())
            {
                //mjpegStream.SignalToStop();
                _ui.mjpegStream.NewFrame -= MJPEGStream_NewFrame;
                _ui.mjpegStream.VideoSourceError -= MJPEGStream_VideoSourceError;
                //mjpegStream.WaitForStop();
                _ui.mjpegStream.Stop(); // the application hangs on close without using this way :( sorry
                _ui.mjpegStream = null;
                _ui.webcamPictureBox.Image?.Dispose(); // ensure the preview is cleared when the stream is stopped
                _ui.AppendLog("Preview stopped.");
            }

            // properly clear the preview box
            if (_ui.webcamPictureBox.Image == null) return;
            _ui.webcamPictureBox.Image.Dispose();
            _ui.webcamPictureBox.Image = null;
        }

        private Bitmap lastStreamFrame;
        private void MJPEGStream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var frame = (Bitmap) eventArgs.Frame.Clone();
            lastStreamFrame = frame;

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

        private int _mjpegStreamErrors;
        private void MJPEGStream_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            //MessageBox.Show($"Video source error: {eventArgs.Description}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _ui.AppendLog($"Video source error: {eventArgs.Description}");
            _mjpegStreamErrors++;
            if (_mjpegStreamErrors < 3) return;
            Stop();
            _ui.AppendLog("Preview stopped due to connection issue");
        }

        public async Task<Bitmap> GetSingleFrameAsync()
        {
            //await LockStream();
            lastStreamFrame = null; // doing this prevents sending a garbled frame...
            while (lastStreamFrame == null) await Task.Delay(100);
            var frame = lastStreamFrame;
            //UnlockStream();
            return frame;
        }

    }
}