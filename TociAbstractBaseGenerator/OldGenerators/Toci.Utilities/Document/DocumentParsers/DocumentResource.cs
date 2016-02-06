using System.IO;
using Toci.Utilities.Interfaces;

namespace Toci.Utilities.Document.DocumentParsers
{
    public class DocumentResource : IDocumentResource
    {
        public Stream Open(string path)
        {
            return new MemoryStream(File.ReadAllBytes(path)) { Position = 0 };
        }
    }
}
