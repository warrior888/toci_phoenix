using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.Logic.InteractiveCourses;

namespace Phoenix.Integration.Test.Developers.Coffee13
{
    [TestClass]
    public class UnitTdbcomunicationtestsest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var obj = new InteractiveCoursersUserAuthorization();

            obj.CheckUserAccountBalance(5, 10);


        }
    }
}
