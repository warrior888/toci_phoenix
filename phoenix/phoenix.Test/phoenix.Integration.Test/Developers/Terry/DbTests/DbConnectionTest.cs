using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
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

            CourseRegistrationBusinessModel test = new CourseRegistrationBusinessModel();

            test.Password = "haszuo";
            test.Email = "test@test.pl";
            test.Name = "Jan";
            test.Surname = "Trzeci";
            test.Nick = "Sobieski";
          //  test.Login = "Sobieski";
            test.ChosenCourses = "c++";

            CourseRegistrationLogic logic = new CourseRegistrationLogic();

            logic.SaveParticipantRegistration(test);
        }
    }
}
