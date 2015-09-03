using System.Collections.Generic;
using toci.pentagram.bll.dblogic;
using toci.pentagram.Dal;
using toci.pentagram.interfaces;
using Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.Interfaces;

namespace Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.logic
{
   public class ApplicationTestsLogicToRand:DataAccessLogic,IApplicationTestsLogicToRand
    {
        public IEnumerable<IApplicationTestsBuisnessModel> GetAllTests()
        {
            return GetAllElements<IApplicationTestsBuisnessModel, ApplicationTests>();
        }
    }
}
