namespace toci.pentagram.logic.FileReader.interfaces
{
    public interface IFileReader<TResult>
    {
        TResult Reader(string path);
        
    }
}