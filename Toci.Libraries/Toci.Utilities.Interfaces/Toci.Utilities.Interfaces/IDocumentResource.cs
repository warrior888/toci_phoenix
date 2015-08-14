using System.IO;

namespace Toci.Utilities.Interfaces
{
    public interface IDocumentResource
    {
        Stream Open(string path);
    }
}
