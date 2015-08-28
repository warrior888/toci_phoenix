using System.IO;
using System.Net.Mime;

namespace toci.pentagram.logic.FileReader.interfaces
{
    public interface IFileReader<TResult>
    {
        TResult Reader(string path);
        
    }
}