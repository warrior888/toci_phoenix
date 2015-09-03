using System;
using System.Drawing;
using System.Linq;
using Toci.Pentagram.Logic.CaptchaLogic.Abstract;
using Toci.Pentagram.Logic.CaptchaLogic.Interfaces;

namespace Toci.Pentagram.Logic.CaptchaLogic.Logic
{
   public class PngParsers:CaptchaPars,ICaptchaParser<string>
   {
        

        public Image ParseImage(string stream)
        {
            string[] allwords = stream.Split(separators, StringSplitOptions.None);
            string thelongesWord = allwords.OrderByDescending(s => widthOfTab * s.Count(x => x == '\t') + s.Count(x => x != '\t'))
                .First();
            int tabsInLongestWord = thelongesWord.Count(x => x == '\t');
            Bitmap image = new Bitmap
                (
                //8- standardowa ilsoc znakow w tab
                (thelongesWord.Length + tabsInLongestWord * widthOfTab - tabsInLongestWord) * FontSize, 
                (stream.Count(x => x == '\n') + 1) * Font.Height
                

                );
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(color);

                g.DrawString(stream, Font, brush, 0, 0);
            }

             // image.Save("obrazek.jpeg", ImageFormat.Jpeg);

            return image;
        }
    }
}
