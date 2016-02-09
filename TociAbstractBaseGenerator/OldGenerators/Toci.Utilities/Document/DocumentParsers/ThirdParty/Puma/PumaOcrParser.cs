using System.Drawing;
using System.IO;
using System.Text;
//using Puma.Net;
using Toci.Utilities.Abstraction.Document;
using Toci.Utilities.Interfaces;

namespace Toci.Utilities.Document.DocumentParsers.ThirdParty.Puma
{
    public class PumaOcrParser : DocumentInterpreter
    {
        protected override StringBuilder Interpret(Stream stream)
        {
            StringBuilder resultText = new StringBuilder();
            Bitmap image = new Bitmap(stream);
            if (image.HorizontalResolution < 300)
            {
                image = PumaOcrHelpers.GetProperDpiImage(image, 300);
            }
            /*var pumaPage = new PumaPage(image);
            using (pumaPage)
            {

                pumaPage.Language = PumaLanguage.Polish;
                pumaPage.FileFormat = PumaFileFormat.TxtAscii;
                pumaPage.RecognizeTables = true;
                pumaPage.UseTextFormating = true;
                pumaPage.PreserveLineBreaks = true;
                pumaPage.ImproveFax100 = true;
                pumaPage.EnableSpeller = true;
                pumaPage.FontSettings.DetectSize = true;
                pumaPage.FontSettings.DetectBold = true;
                pumaPage.FontSettings.DetectItalic = true;
                resultText.Append(pumaPage.RecognizeToString());
                pumaPage.Dispose();
            }*/
            return resultText;
        }

        public PumaOcrParser(IDocumentResource documentResource) : base(documentResource){ }
    }
}
