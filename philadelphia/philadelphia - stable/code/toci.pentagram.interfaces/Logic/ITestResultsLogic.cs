using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toci.pentagram.interfaces.Logic
{
   public interface ITestResultsLogic
    {
        ITestResultsBuisnessModel GetResultsById(int id);
    }
}
