using toci.pentagram.logic.FileReader.interfaces;

namespace toci.pentagram.logic.FileReader.Abstract
{

public abstract class Reader<T>
{
    
    protected IFileReader<T> _readFile;

   protected Reader(IFileReader<T> readFile)
   {
       _readFile = readFile;
       
   }

   
  
}
}
