using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toci.Utilities.Common.Enums;
using Toci.Utilities.Common.String;
using Toci.Utilities.Interfaces;
using Toci.Utilities.Interfaces.Document;
using Toci.Utilities.Interfaces.Document.DocumentParse;
using Toci.Utilities.Interfaces.Document.DocumentRecognition;

namespace Toci.Utilities.Abstraction.Document
{
    public abstract class Document<TKey, TValue> : IDocument<TKey, TValue>
    {
        // TODO imo here a stack of recognizers, for ChoR, can be done in a constructor of a derived class
        protected List<IDocumentRecognizer<TKey, TValue>> DocumentRecognizers;

        protected IDocumentInterpreterFactory DocumentInterpreterFactory;
        protected IDocumentResource DocumentResource;

        protected Document(
            IDocumentResource documentResource,
            IDocumentInterpreterFactory documentInterpreterFactory
            )
        {
            DocumentResource = documentResource;
            DocumentInterpreterFactory = documentInterpreterFactory;
        }

        public virtual Dictionary<TKey, TValue> GetContent(string path)
        {
            IDocumentInterpreter interpreter = DocumentInterpreterFactory.CreateInterpreter(PathUtilities.GetExtension(path));
            StringBuilder docText = interpreter.ParseDocument(path);
            Dictionary<DocumentTypes, double> mostAccurateRecognizer = GetMostAccurateRecognizer(docText);

            // new version, need tests
            return DocumentRecognizers.Where(
                item => item.GetDocumentType() == mostAccurateRecognizer.First().Key).Select(
                item => item.GetDocumentData(docText)).First();

            // old version with foreach
            //if (recognizer.GetDocumentType() == mostAccurateRecognizer.First().Key)
            //return new Dictionary<TKey, TValue>();
        }

        private Dictionary<DocumentTypes, double> GetMostAccurateRecognizer(StringBuilder docText)
        {
            Dictionary<DocumentTypes, double> mostAccurateRecognizer = new Dictionary<DocumentTypes, double>();
           
            foreach (var recognizer in DocumentRecognizers)
            {
                var recognizerResult = recognizer.GetRecognitionValue(docText);

                if (mostAccurateRecognizer.Count == 0)
                {
                    mostAccurateRecognizer = recognizerResult;
                }
                else if (mostAccurateRecognizer.First().Value < recognizerResult.First().Value)
                {
                    mostAccurateRecognizer = recognizerResult;
                }
            }
            return mostAccurateRecognizer.First().Value < 0.5 ? new Dictionary<DocumentTypes, double>() : mostAccurateRecognizer;
        }
    }
}
