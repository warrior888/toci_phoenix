using System.IO;
using System.Text;
using Toci.Utilities.Interfaces;
using Toci.Utilities.Interfaces.Document.DocumentParse;

namespace Toci.Utilities.Abstraction.Document
{
    public abstract class DocumentInterpreter : IDocumentInterpreter
    {
        protected IDocumentResource DocumentResource;
        private string _path;

        protected DocumentInterpreter(IDocumentResource documentResource)
        {
            DocumentResource = documentResource;
        }

        public virtual StringBuilder ParseDocument(string path)
        {
            _path = path;
            var stream = DocumentResource.Open(path);

            return Interpret(stream);
        }

        public virtual string GetFilePath()
        {
            return _path;
        }

        //TODO read all and return strbuilder - with different tools, create derived classes pdf doc interpreter, png docx etc
        protected abstract StringBuilder Interpret(Stream stream);
    }
}
