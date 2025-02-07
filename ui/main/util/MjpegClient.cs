namespace FlashForgeUI.ui.main.util
{
    using System;
    using System.IO;
    using System.Net;
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;

    // todo further optimization and testing
    public class MjpegClient : IDisposable
    {
        public event EventHandler<Bitmap> FrameReceived;
        public event EventHandler<string> StreamError;
        
        private CancellationTokenSource _cancellation;
        private bool _isRunning;
        private readonly object _lock = new object();
        private Bitmap _lastFrame;

        public bool IsRunning => _isRunning;

        public MjpegClient()
        {
            _cancellation = new CancellationTokenSource();
        }

        public void Start(string url)
        {
            if (_isRunning) return;

            _cancellation = new CancellationTokenSource();
            _isRunning = true;
            Task.Run(() => StreamLoop(url), _cancellation.Token);
        }

        public void Stop()
        {
            if (!_isRunning) return;

            _cancellation.Cancel();
            _isRunning = false;
        }

        private async Task StreamLoop(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = true;
                request.Timeout = 5000;
                
                // todo more error handling
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                using (var stream = new BufferedStream(response.GetResponseStream()))
                using (var reader = new BinaryReader(stream))
                {
                    while (!_cancellation.Token.IsCancellationRequested)
                    {
                        var frame = ReadFrame(reader);
                        if (frame == null) continue;
                        lock (_lock)
                        {
                            _lastFrame?.Dispose();
                            _lastFrame = frame;
                        }
                        FrameReceived?.Invoke(this, frame);
                    }
                }
            }
            catch (Exception) when (_cancellation.Token.IsCancellationRequested)
            {
                // Normal shutdown, ignore
            }
            catch (Exception ex)
            {
                StreamError?.Invoke(this, ex.Message);
                Console.WriteLine($"Stream error: {ex.Message}");
            }
            finally
            {
                _isRunning = false;
            }
        }
        
        private readonly byte[] _buffer = new byte[512 * 1024]; // 512 KB buffer

        private Bitmap ReadFrame(BinaryReader reader)
        {
            try
            {
                int index = 0;
                byte prev = 0, curr;
                bool startFound = false;

                while (true)
                {
                    curr = reader.ReadByte();

                    if (!startFound)
                    {
                        if (prev == 0xFF && curr == 0xD8)
                        {
                            startFound = true;
                            _buffer[index++] = 0xFF;
                            _buffer[index++] = 0xD8;
                        }
                    }
                    else
                    {
                        _buffer[index++] = curr;
                        if (prev == 0xFF && curr == 0xD9) break;
                    }

                    prev = curr;

                    if (index >= _buffer.Length) return null;
                }

                using (var ms = new MemoryStream(_buffer, 0, index, false)) return new Bitmap(ms);
            }
            catch
            {
                return null;
            }
        }


        public void Dispose()
        {
            Stop();
            _cancellation.Dispose();
            lock (_lock)
            {
                _lastFrame?.Dispose();
            }
        }
    }
}
