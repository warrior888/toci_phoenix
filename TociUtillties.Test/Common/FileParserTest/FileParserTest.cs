using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Document.DocumentParsers.OCR;
using Toci.Utilities.Document.DocumentRecognition;
using System.Drawing;
using System.Net.Mime;

namespace TociUtillties.Test.Common.FileParserTest
{
    [TestClass]
    public class FileParserTest
    {
        [TestMethod]
        public void TestPdfParser()
        {
            // get file logic
            string filePath = @"..\..\..\Toci.Utilities\Document\DocumentParsers\PDF\data\sample.pdf";
            var validParser = FileRecognizer.GetParser(FileRecognizer.GetExt(filePath));
            var pasedFile = validParser.Parse(filePath);
        }
        [TestMethod]
        public void TestOcrGeneral()
        {
            string filePath = @"..\..\..\Toci.Utilities\Document\DocumentParsers\OCR\img\ex1.jpg";

        }

    }
}
