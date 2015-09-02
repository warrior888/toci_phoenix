using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Document.DocumentParsers;
using Toci.Utilities.Document.DocumentParsers.ThirdParty.Tesseract;

namespace Toci.Utilities.Test.Developers.Chmura
{
    [TestClass]
    public class OcrParserTest
    {
        [TestMethod]     
        public void TestOcr()
        {
            string path = @"..\..\..\Toci.Utilities\Document\DocumentParsers\OCR\img\ex10.jpg";
           // PumaOcrParser parser = new PumaOcrParser(new DocumentResource());
            //parser.ParseDocument(path);
            TesseractOcrParser parser = new TesseractOcrParser(new DocumentResource());
            parser.ParseDocument(path);
        }

    }
}
