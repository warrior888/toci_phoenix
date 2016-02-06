using System.Collections.Generic;
using System.Text;
using Toci.Utilities.Common.Enums;
using Toci.Utilities.Interfaces.Document.DocumentRecognition;

namespace Toci.Utilities.Abstraction.Document
{
    public abstract class DocumentRecognizer<TKey, TValue> : IDocumentRecognizer<TKey, TValue>
    {
        // InvoiceDocumentRecognizer
        protected List<TKey> Checklist;
        protected List<TKey> ExpectedData;
        protected DocumentTypes DocumentType;

        // in construct in derivative
        // Checklist = new list ... { fdsafadsfads } 
        // ExpectedData = new list ... { fdsafadsfads } 
        // DocumentType =  DocumentTypes.(Doc, pdf, etc.)

        public DocumentTypes GetDocumentType()
        {
            return DocumentType;
        }

        public virtual Dictionary<DocumentTypes, double> GetRecognitionValue(StringBuilder content)
        {
            double trueCounter = 0;
            double falseCounter = 0;

            foreach (var toCheck in Checklist)
            {
                if(content.ToString().Contains(toCheck.ToString()))
                    trueCounter++;
                else
                    falseCounter++;
            }

            return new Dictionary<DocumentTypes, double>() { {DocumentType, trueCounter / falseCounter} };
        }

        public virtual Dictionary<TKey, TValue> GetDocumentData(StringBuilder content)
        {
            var documentData = new Dictionary<TKey, TValue>();
            
            foreach(var data in ExpectedData)
            {
                if (content.ToString().Contains(data.ToString()))
                {
                    documentData.Add(data, GetContentValue(data, content));
                }
            }

            return documentData;
        }

        protected abstract TValue GetContentValue(TKey dataKey, StringBuilder content);
    }
}
