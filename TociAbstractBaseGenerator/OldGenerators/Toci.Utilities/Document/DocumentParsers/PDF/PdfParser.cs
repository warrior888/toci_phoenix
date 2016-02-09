using System;
using System.IO;
using System.Text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;
using Toci.Utilities.Abstraction.Document;
using Toci.Utilities.Interfaces;

namespace Toci.Utilities.Document.DocumentParsers.PDF
{
    public class PdfParser : DocumentInterpreter
    {
        //const string fileName = @"..\..\..\Toci.Utilities\Document\DocumentRecognizers\PDF\data\sample.pdf";
        public PdfParser(IDocumentResource documentResource) : base(documentResource) { }

        protected override StringBuilder Interpret(Stream stream)
        {
            /*
            PdfReader reader = new PdfReader(stream);
            StringBuilder result = new StringBuilder();
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                ITextExtractionStrategy its = new LocationTextExtractionStrategy();
                String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                //s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, byte[] dasa));
                result.Append(s);
            }
            return result;
            */
            return null;
        }
    }
}
