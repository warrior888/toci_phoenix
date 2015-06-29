using System.Collections.Generic;

namespace Toci.Utilities.Interfaces.Document
{
    public interface IDocument<TKey, TValue>
    {
        Dictionary<TKey, TValue> GetContent(string path);
    }
}
