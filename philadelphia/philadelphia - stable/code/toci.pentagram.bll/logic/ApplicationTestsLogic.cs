using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toci.pentagram.bll.Buisnessmodel;
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
