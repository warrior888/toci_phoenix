using System;
using System.Data;
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

            DataRow[] foundRows = data.Tables[0].Select("id=" + userId);
            var userActualAccountBalance = foundRows[0]["account_balance"];

            return Convert.ToDecimal(userActualAccountBalance) >= usersMinAccountBalance;
        }
    }
}