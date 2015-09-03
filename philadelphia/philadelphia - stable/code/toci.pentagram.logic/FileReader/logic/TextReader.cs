using System.IO;
using toci.pentagram.logic.FileReader.interfaces;

namespace toci.pentagram.logic.FileReader.logic
{
    public class TextReader:IFileReader<string>
    {
        public string Reader(string path)
        {
            StreamReader reader = new StreamReader(path);
           return reader.ReadToEnd();
        }
    }
}
