using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toci.pentagram.interfaces
{
   public interface IApplicationTestsLogic
   {
       IApplicationTestsBuisnessModel GetTestById(int id);
   }
}
