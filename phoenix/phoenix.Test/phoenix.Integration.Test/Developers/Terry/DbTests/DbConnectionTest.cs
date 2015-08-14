using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Logic.CourseRegistration;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Bll.Logic.UsersList;
using Phoenix.Bll.User;
using Phoenix.Dal.GeneratedModels;
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
            //DeveloperListLogic devListLogic = new DeveloperListLogic();
            //devListLogic.GetDevById(5);

            UsersLogic usersLogic = new UsersLogic();
            var allUsers = usersLogic.GetAllUsers();
            var userById = usersLogic.GetUserById(3);
        }
}
}
