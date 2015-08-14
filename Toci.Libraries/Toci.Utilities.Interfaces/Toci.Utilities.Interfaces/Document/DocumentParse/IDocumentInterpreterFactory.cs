namespace Toci.Utilities.Interfaces.Document.DocumentParse
{
    public interface IDocumentInterpreterFactory
    {
        IDocumentInterpreter CreateInterpreter(string extension);
    }
}
