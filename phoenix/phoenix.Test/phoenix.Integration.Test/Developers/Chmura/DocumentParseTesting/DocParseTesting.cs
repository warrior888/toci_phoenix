using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Document.DocumentParsers;
using Toci.Utilities.Document.DocumentParsers.DOC;

namespace Phoenix.Integration.Test.Developers.Chmura.DocumentParseTesting
{
    [TestClass]
    public class DocParseTesting
    {
        [TestMethod]
        public void TestDocParse()
        {
            string docFile = @"..\..\..\..\..\Toci.Utilities\Document\DocumentParsers\DOC\Sample\sample1.doc";
            string docxFile = @"..\..\..\..\..\Toci.Utilities\Document\DocumentParsers\DOC\Sample\sample2.docx";
//            string xmlFile = @"..\..\..\..\..\Toci.Utilities\Document\DocumentParsers\DOC\Sample\sample3.xml";
//            string otdFile = @"..\..\..\..\..\Toci.Utilities\Document\DocumentParsers\DOC\Sample\sample4.odt"; 

            DocParser parser = new DocParser(new DocumentResource());

            var doc = parser.ParseDocument(docFile);
            var docx = parser.ParseDocument(docxFile);
            //var xml = parser.ParseDocument(xmlFile); Not working for document in xml
            //var otd = parser.ParseDocument(otdFile); // not working for open office
        }
    }
}