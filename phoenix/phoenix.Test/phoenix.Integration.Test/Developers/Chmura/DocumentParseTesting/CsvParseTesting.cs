using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Document.DocumentParsers;
using Toci.Utilities.Document.DocumentParsers.CSV;

namespace Phoenix.Integration.Test.Developers.Chmura.DocumentParseTesting
{
    [TestClass]
    public class CsvParseTesting
    {
        [TestMethod]
        public void TestCsvParse()
        {
            string sample1 = @"..\..\..\..\..\Toci.Utilities\Document\DocumentParsers\CSV\Sample\sample1.csv";
            string sample2 = @"..\..\..\..\..\Toci.Utilities\Document\DocumentParsers\CSV\Sample\sample2.csv";

            CsvParser parser = new CsvParser(new DocumentResource());

            var s1 = parser.ParseDocument(sample1);
            var s2 = parser.ParseDocument(sample2);
        }
    }
}