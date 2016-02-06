using System.Collections.Generic;
using System.Text;
using Toci.Utilities.Common.Enums;

namespace Toci.Utilities.Interfaces.Document.DocumentRecognition
{
    public interface IDocumentRecognizer<TKey, TValue>
    {
        Dictionary<DocumentTypes, double> GetRecognitionValue(StringBuilder content);

        Dictionary<TKey, TValue> GetDocumentData(StringBuilder content);

        DocumentTypes GetDocumentType();
    }
}
