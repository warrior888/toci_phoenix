namespace toci.pentagram.logic.FileReader.interfaces
{
    public interface IGetFileExtension
    {
        string path { get; set; }
        string getFileExtension(string path);
    }
}