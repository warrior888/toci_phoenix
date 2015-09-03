using toci.pentagram.bll.dblogic;
using toci.pentagram.Dal;
using toci.pentagram.interfaces;

namespace toci.pentagram.bll.logic
{
   public class ApplicationTestsLogic:DataAccessLogic,IApplicationTestsLogic
    {
        

     public   IApplicationTestsBuisnessModel GetTestById(int id)
        {
            return GetElementById<IApplicationTestsBuisnessModel, ApplicationTests>(id);
        }
    }
}
