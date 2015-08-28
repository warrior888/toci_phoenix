using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Dal.GeneratedModels;
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
