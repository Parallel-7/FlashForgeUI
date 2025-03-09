using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using AForge.Video;
using FlashForgeUI.ui.main.util;

namespace FlashForgeUI.ui.main.manager.camera
{
    public class MjpegStreamManager
    {
        private readonly CameraHelper _camHelper;

        private readonly MainMenu _ui;

        private Bitmap _lastFrame;
        private Stopwatch _lastFrameTime = new Stopwatch();
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private CancellationToken _ct;

        private int _mjpegStreamErrors;
        

        public MjpegStreamManager(MainMenu form1)
        {
            _ui = form1;
            _camHelper = new CameraHelper(form1);
        }

        public void Start()
        {
            string url;
            if (_ui.Config.CustomCamera) // check for custom camera url
            {
                // allow users to use placeholders for the IP
                url = _ui.Config.CustomCameraUrl.Replace("{IpAddress}", _ui.PrinterClient.IpAddress);
                Console.WriteLine("Using custom camera url: " + url);
            }
            else url = $"http://{_ui.PrinterClient.IpAddress}:8080/?action=stream";
            
            _ui.MjpegStream = new MJPEGStream(url);
            _ui.MjpegStream.NewFrame += MJPEGStream_NewFrame;
            _ui.MjpegStream.VideoSourceError += MJPEGStream_VideoSourceError;
            _ui.MjpegStream.Start();
            
            StartFrameMonitor();
        }

        private void StartFrameMonitor()
        {
            _lastFrameTime.Start();
            _cts = new CancellationTokenSource();
            _ct = _cts.Token;
            FrameMonitor();
        }

        private void StopFrameMonitor()
        {
            _cts.Cancel();
            _lastFrameTime.Reset();
        }
        

        private void FrameMonitor()
        {
            Task.Run(async () => 
            {
                while (!_ct.IsCancellationRequested)
                {
                    if (_lastFrameTime.ElapsedMilliseconds > 5000)
                    {
                        Console.WriteLine("Mjpeg frame took longer than 5s, timed out.");
                        StopFrameMonitor();
                        StopError();
                    }
                    await Task.Delay(50);
                }
            });
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
            
            StopFrameMonitor();
            _camHelper.ResetPreview();
        }

        private void MJPEGStream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var frame = (Bitmap)eventArgs.Frame.Clone();
            _lastFrame = frame;
            _lastFrameTime.Restart();

            _camHelper.SetFrame(frame);
        }

        private void MJPEGStream_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            _ui.AppendLog($"Video source error: {eventArgs.Description}");
            _mjpegStreamErrors++;
            if (_mjpegStreamErrors < 3) return;
            StopError();
        }

        private void StopError()
        {
            Utils.SetButtonText(_ui.toggleWebcamButton, "Preview On");
            _ui.AppendLog("Preview stopped due to connection issue");
            _mjpegStreamErrors = 0;
            Stop();
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