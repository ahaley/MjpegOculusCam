using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using MjpegProcessor;

namespace CLEyeMulticam
{
    public class MjpegCameraImage : Image, IDisposable
    {
        private MjpegDecoder decoder;

        public MjpegCameraImage()
        {
        }

        public void SetDecoder(MjpegDecoder decoder)
        {
            this.decoder = decoder;
            this.decoder.FrameReady += FrameReady;
        }

        private void FrameReady(object sender, FrameReadyEventArgs e)
        {
            Source = e.BitmapImage;
        }

        public float Framerate
        {
            get;
            set;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }
    }
}
