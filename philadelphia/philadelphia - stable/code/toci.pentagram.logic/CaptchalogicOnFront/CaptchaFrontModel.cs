using toci.pentagram.bll.logic;
using toci.pentagram.interfaces;
using toci.pentagram.logic.CaptchalogicOnFront.interfaces;
using toci.pentagram.logic.CaptchaLogic.Interfaces;
using toci.pentagram.logic.CaptchaLogic.RandomTCaptchaLogic.logic;
using Toci.Pentagram.Logic.CaptchaLogic.Logic;

namespace toci.pentagram.logic.CaptchalogicOnFront
{
    public class CaptchaFrontModel:ICaptchaFront
    {
        private IRandId RandomId;
        private IApplicationTestsBuisnessModel test;
        private IApplicationTestsLogic logic;
        private Toci.Pentagram.Logic.CaptchaLogic.Logic.CaptchaLogic captchalogic;

        public CaptchaFrontModel()
        {
            captchalogic=new Toci.Pentagram.Logic.CaptchaLogic.Logic.CaptchaLogic(new PngParsers());
           // test=new ApplicationTestsBuisnessModel();
            logic = new ApplicationTestsLogic();
            RandomId = new RandIDLogic();
        }



        public string GetAndShowRandQuestion()
        {
            test = logic.GetTestById(RandomId.RandId());
            return captchalogic.ConvertToBase64(test.Codesnipet);
        }

        public bool Compare(string answer)
        {
            return false;
            //porownanie po stringu ????????
        }
    }
}