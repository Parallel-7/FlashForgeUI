using System;
using System.Drawing;
using System.Threading.Tasks;
using AForge.Video;

namespace FlashForgeUI.ui.main.manager.camera
{
    public class MjpegStreamManager
    {
        private readonly CameraHelper _camHelper;

        private readonly MainMenu _ui;

        private Bitmap _lastFrame;

        private int _mjpegStreamErrors;

        public MjpegStreamManager(MainMenu form1)
        {
            _ui = form1;
            _camHelper = new CameraHelper(form1);
        }

        public void Start()
        {
            if (_ui.Config.CustomCamera) // check for custom camera url
            {
                // allow users to use placeholders for the IP
                var url = _ui.Config.CustomCameraUrl.Replace("{IpAddress}", _ui.PrinterClient.IpAddress);
                _ui.MjpegStream = new MJPEGStream(url);
                Console.WriteLine("Using custom camera url: " + url);
            }
            else
            {
                _ui.MjpegStream =
                    new MJPEGStream(
                        $"http://{_ui.PrinterClient.IpAddress}:8080/?action=stream"); // default for the 5M pro
            }

            _ui.MjpegStream.NewFrame += MJPEGStream_NewFrame;
            _ui.MjpegStream.VideoSourceError += MJPEGStream_VideoSourceError;
            _ui.MjpegStream.Start();
        }

        public bool IsRunning()
        {
            return _ui.MjpegStream != null && _ui.MjpegStream.IsRunning;
        }

        public void Stop()
        {
            if (IsRunning())
            {
                _ui.MjpegStream.NewFrame -= MJPEGStream_NewFrame;
                _ui.MjpegStream.VideoSourceError -= MJPEGStream_VideoSourceError;
                _ui.MjpegStream.Stop();
                _ui.MjpegStream = null;
            }

            _camHelper.ResetPreview();
        }

        private void MJPEGStream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var frame = (Bitmap)eventArgs.Frame.Clone();
            _lastFrame = frame;

            _camHelper.SetFrame(frame);
        }

        private void MJPEGStream_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            _ui.AppendLog($"Video source error: {eventArgs.Description}");
            _mjpegStreamErrors++;
            if (_mjpegStreamErrors < 3) return;
            Stop();
            _ui.toggleWebcamButton.Text = "Preview On";
            _ui.AppendLog("Preview stopped due to connection issue");
        }

        public async Task<Bitmap> GetSingleFrameAsync()
        {
            _lastFrame = null; // doing this prevents sending a garbled frame...
            while (_lastFrame == null) await Task.Delay(100);
            var frame = _lastFrame;
            return frame;
        }
    }
}