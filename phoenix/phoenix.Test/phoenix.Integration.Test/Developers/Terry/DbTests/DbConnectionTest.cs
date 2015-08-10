using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.Logic.CourseRegistration;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.Clients;
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
            DbHandleAccessData.Password = "ph03n1x";
            DbHandleAccessData.DbAdress = "localhost";
            DbHandleAccessData.DbName = "Phoenix";
            DbHandleAccessData.UserName = "postgres";
            
            CourseRegistrationLogic test = new CourseRegistrationLogic();



        }
    }
}
