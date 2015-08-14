using System.Text;

namespace Toci.Utilities.Interfaces.Document.DocumentParse
{
    public interface IDocumentInterpreter
    {
        StringBuilder ParseDocument(string path);
    }
}
