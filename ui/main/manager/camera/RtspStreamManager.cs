using System;
using System.Drawing;
using System.Threading.Tasks;
using RtspClientSharp;
using System.Threading;
using RtspClientSharp.RawFrames;

namespace FlashForgeUI.ui.main.manager.camera
{
    // Handle all other camera stream types (over RTSP or tunneled through HTTP)
    // Could NOT get this to work on the default 5M camera :(
    public class RtspStreamManager
    {
        private readonly MainMenu _ui;
        private readonly CameraHelper _camHelper;
        
        private RtspClient _rtspClient;
        public bool IsRunning;

        private CancellationTokenSource _cts;

        public RtspStreamManager(MainMenu mainMenu)
        {
            _ui = mainMenu;
            _camHelper = new CameraHelper(mainMenu);
        }

        public async Task Start()
        {
            if (!_ui.Config.CustomCamera || string.IsNullOrEmpty(_ui.Config.CustomCameraUrl))
            {
                Console.WriteLine("Cannot start RtspStreamManager, not using custom camera and/or URL is not properly set");
                return;
            }
            
            var connectionParameters = new ConnectionParameters(new Uri(_ui.Config.CustomCameraUrl.Replace("{IpAddress}", _ui.PrinterClient.IpAddress)));
            
            _rtspClient = new RtspClient(connectionParameters);
            _rtspClient.FrameReceived += OnFrameReceived;

            _cts = new CancellationTokenSource();
            IsRunning = true;
            await _rtspClient.ConnectAsync(_cts.Token); // connect
            await _rtspClient.ReceiveAsync(_cts.Token); // start streaming
        }

        public void Stop()
        {
            _rtspClient.FrameReceived -= OnFrameReceived;
            _cts.Cancel();
            _rtspClient.Dispose();
            _camHelper.ResetPreview();
            IsRunning = false;
        }
        

        private void OnFrameReceived(object sender, RawFrame rawFrame)
        {
            // todo this needs to be tested
            var bitmap = _camHelper.RawFrameToBitmap(rawFrame);
            if (bitmap != null) _camHelper.SetFrame(bitmap);

        }
        
        private Bitmap _lastStreamFrame;
        public async Task<Bitmap> GetSingleFrameAsync()
        {
            _lastStreamFrame = null; // Prevents sending a garbled frame...
            while (_lastStreamFrame == null) await Task.Delay(100);
            var frame = _lastStreamFrame;
            return frame;
        }
    }
}
