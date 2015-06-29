using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Common.String;
using Toci.Utilities.Document.DocumentParsers;
using Toci.Utilities.Interfaces.Document.DocumentParse;

namespace Toci.Utilities.Test.Developers.Chmura
{
    [TestClass]
    public class PdfParserTest
    {
        [TestMethod]
        public void TestPdfParseResoult()
        {
            string fileName = @"..\..\..\Toci.Utilities\Document\DocumentParsers\PDF\data\sample.pdf";
            IDocumentInterpreter interpreter =  new DocumentInterpreterFactory().CreateInterpreter(PathUtilities.GetExtension(fileName));
            StringBuilder docText = interpreter.ParseDocument(fileName);
        }
    }
}