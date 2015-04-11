using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageResizer
{
    public class ResizerService
    {
        // http://www.codeproject.com/Articles/191424/Resizing-an-Image-On-The-Fly-using-NET

        public Stream Resize(Stream image, Size maxSize)
        {
            using (var originalImage = Image.FromStream(image))
            {
                var newSize = Redimension(originalImage.Size, maxSize);
                using (var newImage = new Bitmap(newSize.Width, newSize.Height))
                {
                    using (Graphics graphicsHandle = Graphics.FromImage(newImage))
                    {
                        graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphicsHandle.DrawImage(originalImage, 0, 0, newSize.Width, newSize.Height);
                    }

                    using (var memStream = new MemoryStream())
                    {
                        newImage.Save(memStream, ImageFormat.Jpeg);
                        return memStream;
                    }
                }
            }
        }

        private Size Redimension(Size currentSize, Size newSize)
        {
            int newWidth;
            int newHeight;
            int originalWidth = currentSize.Width;
            int originalHeight = currentSize.Height;
            float percentWidth = (float)newSize.Width / (float)originalWidth;
            float percentHeight = (float)newSize.Height / (float)originalHeight;
            float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
            newWidth = (int)(originalWidth * percent);
            newHeight = (int)(originalHeight * percent);

            return new Size(newWidth, newHeight);
        }
    }
}
