using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toci.pentagram.interfaces;
using toci.pentagram.logic.CaptchaLogic.Interfaces;
using Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.Interfaces;
using Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.logic;

namespace toci.pentagram.logic.CaptchaLogic.RandomTCaptchaLogic.logic
{
  public  class RandIDLogic:IRandId
    {
        private IApplicationTestsLogicToRand testsRand;

       public RandIDLogic()
        {
            testsRand=new ApplicationTestsLogicToRand();
        }



        public int RandId()
        {
            return 0;
        }


    /*  private int GetId(IEnumerable<IApplicationTestsBuisnessModel> tests)
      {
          List<int> listId=tests.Select(item=>item.Codesnipet)
      }*/
    }
}
