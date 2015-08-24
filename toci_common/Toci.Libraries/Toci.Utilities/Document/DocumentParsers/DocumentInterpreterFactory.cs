using System;
using System.Collections.Generic;
using Toci.Utilities.Document.DocumentParsers.DOC;
using Toci.Utilities.Document.DocumentParsers.PDF;
using Toci.Utilities.Document.DocumentParsers.ThirdParty.Puma;
using Toci.Utilities.Interfaces.Document.DocumentParse;

namespace Toci.Utilities.Document.DocumentParsers
{
    public class DocumentInterpreterFactory : IDocumentInterpreterFactory
    {
        private static Dictionary<string, Func<IDocumentInterpreter>> parsers = new Dictionary
            <string, Func<IDocumentInterpreter>>()
        {
            {"pdf",()=>new PdfParser(new DocumentResource())}, 

            {"bmp",()=>new PumaOcrParser(new DocumentResource())},
            {"png",()=>new PumaOcrParser(new DocumentResource())},
            {"jpg",()=>new PumaOcrParser(new DocumentResource())},
           // {"bmp",()=>new OcrParser(new DocumentResource())},
           // {"png",()=>new OcrParser(new DocumentResource())},
           // {"jpg",()=>new OcrParser(new DocumentResource())},
            {"doc",()=>new DocParser(new DocumentResource())},
            {"docx",()=>new DocParser(new DocumentResource())}

        };
        public IDocumentInterpreter CreateInterpreter(string extension)
        {
            return parsers.ContainsKey(extension) ? parsers[extension]() : null;
        }


    }
}