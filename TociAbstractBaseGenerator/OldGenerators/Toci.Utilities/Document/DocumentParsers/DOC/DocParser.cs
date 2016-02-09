using System.IO;
using System.Text;
//using Code7248.word_reader;
using Toci.Utilities.Abstraction.Document;
using Toci.Utilities.Interfaces;

namespace Toci.Utilities.Document.DocumentParsers.DOC
{
    public class DocParser : DocumentInterpreter
    {
        // working for Doc / Docx, resoult is without /n characters
        public DocParser(IDocumentResource documentResource) : base(documentResource)
        {
        }

        protected override StringBuilder Interpret(Stream stream)
        {
            //TextExtractor extractor = new TextExtractor(GetFilePath());
            //return new StringBuilder(extractor.ExtractText());
            return null;
        }
    }
}