using Phoenix.Bll.Interfaces.Logic.InteractiveCourses;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.ClusterAccess;

namespace Phoenix.Bll.Logic.InteractiveCourses
{
    public class InteractiveCoursersUserAuthorization : IInteractiveCoursesUserAuthorization
    {
        public bool CheckUserAccountBalance(int userId,decimal usersMinAccountBalance)
        {
            var dbhandle = DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, "web", "mateusz", "localhost", "ic_database");
            var data = dbhandle.GetData(new users());

            
            
            //dataset obsługa i compare 



            return true;
        }
    }
}