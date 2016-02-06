using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Toci.Db.DbVirtualization;
using Toci.Db.DbVirtualization.PostgreSqlQuery;
using Toci.Db.DbVirtualization.MsSqlQuery;

namespace Toci.Utilities.Test.Developers.Kielich
{
    [TestClass]
    public class Select
    {
        [TestMethod]
        public void SelectTest()
        {
            PostgreSqlSelect select = new PostgreSqlSelect();
            TestModel test = new TestModel("table");

            test.Age = 35;
            test.Height = 100;
            test.City = "Hiroshima";

            test.SetSelect("age", SelectClause.Equal);
            test.SetSelect("height", SelectClause.NotEqual);
            test.SetSelect("city", SelectClause.Like);
 
            var res = select.GetQuery(test);

            Assert.AreEqual("SELECT age,height,city FROM table WHERE age = 35 AND height != 100 AND city LIKE 'Hiroshima'", res);
            //Assert.AreEqual("SELECT city FROM table", res);
        }
    }
}

