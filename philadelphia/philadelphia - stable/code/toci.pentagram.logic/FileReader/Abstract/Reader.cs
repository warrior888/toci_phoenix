using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Dal.GeneratedModels;
using toci.pentagram.logic.FileReader.interfaces;
using toci.pentagram.logic.FileReader.logic;

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
