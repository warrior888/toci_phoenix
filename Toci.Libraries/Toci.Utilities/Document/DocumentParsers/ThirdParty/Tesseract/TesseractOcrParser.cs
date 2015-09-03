using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using Tesseract;
using Toci.Utilities.Abstraction.Document;
using Toci.Utilities.Interfaces;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace Toci.Utilities.Document.DocumentParsers.ThirdParty.Tesseract
{
    public class TesseractOcrParser : DocumentInterpreter
    {
        const string tessdataPath = @"C:/Users/Mateusz/Desktop/tessdata";
        const string language = "pol";
        private TesseractEngine engine = new TesseractEngine(tessdataPath, language);

        public TesseractOcrParser(IDocumentResource documentResource): base(documentResource)
        {                                          
        }

        protected override StringBuilder Interpret(Stream stream)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Bitmap image = new Bitmap(stream);
            IEnumerable<Word> result = OcrAndIterateWords(image);
            foreach (var item in result)
            {
                stringBuilder.Append(item.Text+" ");
            }             

            return stringBuilder;


        }
        /// <summary>
        /// Klasa pomocnicza reprezentująca słowo (do iterowania po słowach)
        /// </summary>
        public class Word
        {
            public string Text { get; set; }
            public Rectangle Bounds { get; set; }
        }

        /// <summary>
        /// Przeskaluj bitmapę do wymaganego DPI. Tesseract wymaga obrazów z odpowiednią rozdzielczością,
        /// inaczej tekst z małym fontem będzie nierozpoznawalny
        /// </summary>
        static Bitmap RescaleToDpi(Image image, int dpiX, int dpiY)
        {
            Bitmap bm = new Bitmap(
                (int)(image.Width * dpiX / image.HorizontalResolution),
                (int)(image.Height * dpiY / image.VerticalResolution),
                image.PixelFormat);
            bm.SetResolution(dpiX, dpiY);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.InterpolationMode = InterpolationMode.Bicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(image, 0, 0, bm.Width, bm.Height);
            }
            return bm;
        }

        /// <summary>
        /// Iteruj po słowach w bitmapie (jak nazwa wskazuje zresztą).
        /// Nie takie proste do napisania jak by się wydawało.
        /// Dodatkowa komplikacja wynika z tego, że trzeba przeskalować
        /// bitmapę do dobrego DPI żeby mieć dobre wyniki
        /// </summary>
        /// IEnumerable<Word>
        IEnumerable<Word> OcrAndIterateWords(Bitmap image)
        {
            const int DesiredDpi = 500;
            var result = RescaleToDpi(image, DesiredDpi, DesiredDpi);
            var scaleX = DesiredDpi / image.HorizontalResolution;
            var scaleY = DesiredDpi / image.VerticalResolution;
            var imageBytes = GetTiffBytes(result);
            var pixels = Pix.LoadTiffFromMemory(imageBytes);
            using (var page = engine.Process(pixels))
            {
                foreach (var word in IteratePage(page))
                {
                    word.Bounds = new Rectangle(
                        (int)(word.Bounds.X / scaleX),
                        (int)(word.Bounds.Y / scaleY),
                        (int)(word.Bounds.Width / scaleX),
                        (int)(word.Bounds.Height / scaleY));                     
                    yield return word;
                }
            }              
        }

        /// <summary>
        /// Iteruj po słowach na przeanalizowanej przez tesseracta stronie (Page) 
        /// Ta metoda to WTF, bo C#owe Api tesseracta jest zrobione jak jest, i trzeba ręcznie
        /// iterować po wszystkich strukturach. Nie można też pomijać żadnych fragmentów (np. brać
        /// od razu następne słowo, bez iterowania po blokach i paragrafach) bo nie (bo nie zadziała).
        /// </summary>
        IEnumerable<Word> IteratePage(Page page)
        {
            using (var iter = page.GetIterator())
            {
                iter.Begin();
                do
                {
                    do
                    {
                        do
                        {
                            do
                            {
                                Rect bounds;
                                iter.TryGetBoundingBox(PageIteratorLevel.Word, out bounds);
                                string text = iter.GetText(PageIteratorLevel.Word) ?? "";
                                yield return new Word
                                {
                                    Text = text,
                                    Bounds = new Rectangle(bounds.X1, bounds.Y1, bounds.Width, bounds.Height)
                                };
                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                } while (iter.Next(PageIteratorLevel.Block));
            }
        }

        /// <summary>
        /// Mały helper, zapisuje bitmapę jako TIFF do tablicy bajtów. 
        /// Bo API wspiera tylko czytanie tiffów z bajtów, a Pix z bitmapy nie działał afaik (bug jakiś)
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        byte[] GetTiffBytes(Bitmap img)
        {
            using (var buffer = new MemoryStream())
            {
                img.Save(buffer, ImageFormat.Tiff);
                return buffer.ToArray();
            }
        }
    }
}
