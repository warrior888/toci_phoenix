using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toci.pentagram.interfaces;

namespace Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.Interfaces
{
   public interface IApplicationTestsLogicToRand
    {
       IEnumerable< IApplicationTestsBuisnessModel> GetAllTests();
    }
}
