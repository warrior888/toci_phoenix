using System;
using System.Linq;
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
            var testy = testsRand.GetAllTests().Select(item=>item.Id).ToList();
           
            return testy[GetId(testy.Count)];
        }


      private int GetId(int ListOfLength)
      {
          Random rand = new Random();
          return rand.Next(ListOfLength);

      }
    }
}
