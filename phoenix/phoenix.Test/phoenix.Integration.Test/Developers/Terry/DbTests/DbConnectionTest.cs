using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            PostgreSqlClient client = new PostgreSqlClient("postgres", "ph03n1x", "localhost", "Phoenix");

           var generator = new TociDbModelGeneratorWrapper();

            CourseRegistrationLogic test = new CourseRegistrationLogic();

           // test.SaveParticipantRegistration()
        }
    }
}
