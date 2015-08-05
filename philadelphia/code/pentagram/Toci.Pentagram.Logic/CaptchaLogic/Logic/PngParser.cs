using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Pentagram.Logic.CaptchaLogic.Abstract;

namespace Toci.Pentagram.Logic.CaptchaLogic.Logic
{

    public class PngParser : ImageData<string, Image>
    {
        private char[] separators = new[] { '\n' };
        private Color color = Color.AliceBlue;
        private Brush brush = Brushes.Black;

        public PngParser()
        {
            FontSize = 18;
            font = new Font("Arial", FontSize);




        }

        public override Image parseImage(string stream)
        {
       
            string[] a = stream.Split(separators, StringSplitOptions.None);
            string thelongesWord = a.OrderByDescending(s => 8 * s.Count(x => x == '\t') + s.Count(x => x != '\t'))
                . First();
            int tabsInLongestWord = thelongesWord.Count(x => x == '\t');
            Bitmap image = new Bitmap
                (
                //8- standardowa ilsoc znakow w tab
                (thelongesWord.Length + tabsInLongestWord * 8) * FontSize,
                (stream.Count(x => x == '\n')+1) * font.Height


                );
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(color);
                
                g.DrawString(stream, font, brush, 0, 0);
            }

            //   image.Save("sss.jpeg",ImageFormat.Jpeg);

            return image;
        }



    }
}
