using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.Logic.InteractiveCourses;

namespace Phoenix.Integration.Test.Developers.Coffee13
{
    [TestClass]
    public class UnitTdbcomunicationtestsest1
    {
        [TestMethod]
        public void TestOfuserAutorization()
        {
            var obj = new InteractiveCoursersUserAuthorization();
            Assert.IsTrue(obj.CheckUserAccountBalance(5, new decimal(10.00)));
            Assert.IsFalse(obj.CheckUserAccountBalance(5,new decimal(100.23)));
        }

        [TestMethod]
        public void TaskOperationsTest()
        {
            var obj =  new InteractiveCoursesTaskOperations();
            Assert.IsFalse(obj.CheckIfUsersTaskExist(5));
            Assert.IsTrue(obj.CheckIfUsersTaskExist(5));
        }
    }
}
