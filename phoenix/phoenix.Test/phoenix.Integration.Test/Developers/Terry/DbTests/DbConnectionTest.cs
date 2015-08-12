using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Logic.CourseRegistration;
//using Phoenix.Dal.GeneratedModels;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator;

namespace Phoenix.Integration.Test.Developers.Terry.DbTests
{
    [TestClass]
    public class DbConnectionTest
    {
        [TestMethod]
        public void DbConnectionTesting()
        {
           /* DbHandleAccessData.Password = "ph03n1x";
            DbHandleAccessData.DbAdress = "localhost";
            DbHandleAccessData.DbName = "Phoenix";
            DbHandleAccessData.UserName = "postgres";

            var handel =  DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, DbHandleAccessData.UserName, DbHandleAccessData.Password,
                DbHandleAccessData.DbAdress, DbHandleAccessData.DbName);*/

          /*  var model = new course_registration()
            {
                email = "test@test.dd",
                login = "login123",
                id_roles = 1,
                id = 4
            };

            var model2 = new course_registration()
            {
                email = "testowanie@test.dd",
                login = "123",
                id_roles = 2,
                
            };


            handel.InsertData(model2);
            handel.UpdateData(new course_registration()
            {
                id_roles = 3,
                login = "iiiiiiiii"
            });*/
        }
    }
}
