using System;
using System.Data;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;
using Phoenix.Bll.Interfaces.Logic.InteractiveCourses;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.ClusterAccess;
using Toci.Db.Interfaces;

namespace Phoenix.Bll.Logic.InteractiveCourses
{
    public class InteractiveCoursesTaskOperations : IInteractiveCourseTaskOperations
    {
        private IDbHandle _handle;

        public InteractiveCoursesTaskOperations()
        {
            _handle = DbHandleFactory.GetHandle(new DbAccessConfig
            {
                ClientKind = SqlClientKind.PostgreSql,
                UserName = "web",
                Password = "mateusz",
                DbAddress = "localhost",
                DbName = "ic_database"
            });
        }

        public bool CheckIfUsersTaskExist(int userId)
        {
            var data = _handle.GetData(new completed_tasks());

            DataRow[] foundRows = data.Tables[0].Select("id=" + userId);
            var usersRecordsAmount = foundRows.Count();

            return usersRecordsAmount != 0;
        }

        public bool InsertUsersFirstRecord(int userId)
        {
            DateTime thisDay = DateTime.Today;

            _handle.InsertData(new completed_tasks 
            {
                DateOfTaskCompletion = thisDay,
                IdLastCompletedTask = 0,
                IdUsers = userId
            });

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