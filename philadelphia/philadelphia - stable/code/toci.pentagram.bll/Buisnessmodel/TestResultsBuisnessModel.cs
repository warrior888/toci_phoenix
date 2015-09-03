using toci.pentagram.interfaces;

namespace toci.pentagram.bll.Buisnessmodel
{
   public class TestResultsBuisnessModel:ITestResultsBuisnessModel
    {
      

        public IApplicationTestsBuisnessModel applicationtests { get; set; }
        public string IdUser { get; set; }
        public string Result { get; set; }
    }
}
