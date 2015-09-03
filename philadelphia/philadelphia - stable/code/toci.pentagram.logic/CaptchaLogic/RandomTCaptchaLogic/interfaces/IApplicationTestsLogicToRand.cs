using System.Collections.Generic;
using toci.pentagram.interfaces;

namespace Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.Interfaces
{
   public interface IApplicationTestsLogicToRand
    {
       IEnumerable< IApplicationTestsBuisnessModel> GetAllTests();
    }
}
