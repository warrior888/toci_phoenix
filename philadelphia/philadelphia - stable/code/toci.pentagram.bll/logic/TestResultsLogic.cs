using Phoenix.Dal.GeneratedModels;
using toci.pentagram.bll.Buisnessmodel;
using toci.pentagram.bll.dblogic;
using toci.pentagram.interfaces;
using toci.pentagram.interfaces.Logic;

namespace toci.pentagram.bll.logic
{
   public class TestResultsLogic:DataAccessLogic, ITestResultsLogic
    {
       public ITestResultsBuisnessModel GetResultsById(int id)
       {
           return GetElementById<TestResultsBuisnessModel, TestsResults>(id);
       }
    }
}
