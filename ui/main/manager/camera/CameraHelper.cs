using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using RtspClientSharp.RawFrames;
using RtspClientSharp.RawFrames.Video;

namespace FlashForgeUI.ui.main.manager.camera
{
    public class CameraHelper
    {

        private MainMenu _ui;

        public CameraHelper(MainMenu mainMenu)
        {
            _ui = mainMenu;
        }
        
        public void SetFrame(Bitmap frame)
        {
            _ui.webcamPictureBox.BeginInvoke(new MethodInvoker(() =>
            {
                ResetImg();
                _ui.webcamPictureBox.Image = frame;
            }));
        }
        
        public void ResetImg()
        {
            _ui.webcamPictureBox.Image?.Dispose();
        }
        
        public void ResetPreview()
        {
            ResetImg();
            _ui.webcamPictureBox.Image = null;
        }

        
        // Todo testing and improvements, etc.
        private Bitmap MakeBitmap(byte[] arr, int index, int count)
        {
            using (var ms = new MemoryStream(arr, index, count)) return new Bitmap(ms);
        }

        private Bitmap MakeBitmap(ArraySegment<byte> frameSegment)
        {
            return frameSegment.Array == null ? null : MakeBitmap(frameSegment.Array, frameSegment.Offset, frameSegment.Count);
        }

        public Bitmap RawFrameToBitmap(RawFrame rawFrame)
        {
            switch (rawFrame)
            {
                case RawJpegFrame jpegFrame:
                    return MakeBitmap(jpegFrame.FrameSegment);
                case RawVideoFrame videoFrame:
                    return MakeBitmap(videoFrame.FrameSegment);
                default:
                    return null;
            }
        }
        

    }
}