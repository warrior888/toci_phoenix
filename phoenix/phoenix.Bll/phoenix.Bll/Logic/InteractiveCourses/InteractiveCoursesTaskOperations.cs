using System.Data;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;
using Phoenix.Bll.Interfaces.Logic.InteractiveCourses;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.ClusterAccess;

namespace Phoenix.Bll.Logic.InteractiveCourses
{
    public class InteractiveCoursesTaskOperations : IInteractiveCourseTaskOperations
    {
        public bool CheckIfUsersTaskExist(int userId)
        {
            var handle = DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, "web", "mateusz", "localhost", "ic_database");
            var data = handle.GetData(new completed_tasks());

            DataRow[] foundRows = data.Tables[0].Select("id=" + userId);
            var usersRecordsAmount = foundRows.Count();

            return usersRecordsAmount != 0;
        }

        public bool InsertUsersFirstRecord(int userId)
        {
            var handle = DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, "web", "mateusz", "localhost", "ic_database");
            handle.InsertData(new completed_tasks {});

            return true;
        }

        public int GetUsersLastTask(int userId)
        {
            throw new System.NotImplementedException();
        }

        public ITask GetUsersNextTask(int userId, int lastTasksId)
        {
            throw new System.NotImplementedException();
        }
    }
}