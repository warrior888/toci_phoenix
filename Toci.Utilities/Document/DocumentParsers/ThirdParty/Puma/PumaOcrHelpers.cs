using System.Drawing;
using System.Drawing.Drawing2D;


namespace Toci.Utilities.Document.DocumentParsers.OCR
{
    public class PumaOcrHelpers
    {
        public static Bitmap GetProperDpiImage(Bitmap bmp, int dpi)
        {
            double scale = (double)dpi/bmp.HorizontalResolution;
            int widthScaled = (int) (bmp.Width*scale);
            int heightScaled = (int) (bmp.Height*scale);
            var newBmp = new Bitmap(widthScaled, heightScaled);
            using ( var graph = Graphics.FromImage(bmp))
            {
                graph.CompositingQuality = CompositingQuality.HighQuality;
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graph.DrawImage(bmp, 0, 0, (int)(bmp.Width * scale), (int)(bmp.Height * scale));
            }
            return bmp;
        }
    }
}
