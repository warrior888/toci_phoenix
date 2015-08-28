using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toci.pentagram.logic.FileReader.Abstract;
using toci.pentagram.logic.FileReader.interfaces;

namespace toci.pentagram.logic.FileReader.logic
{
   public class TextReaderLogic:Reader<string>,ITextReaderLogic
    {
       public TextReaderLogic(IFileReader<string> readFile) : base(readFile)
       {
           
       }


       public string GetValue(string path)
       {
           return _readFile.Reader(path);
       }
    }
}
