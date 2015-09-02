using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.DbVirtualization;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace Toci.Utilities.Test.Developers.Kielich
{
    [TestClass]
    public class Select
    {
        private const string TmpQuery = "SELECT age,height,city FROM table WHERE age = 35 AND height != 100 AND city LIKE 'Hiroshima'";
        private const string SubstringKeyword = "WHERE";

        [TestMethod]
        public void SelectTest()
        {
            PostgreSqlSelect postgreSqlSelect = new PostgreSqlSelect();
            MsSqlSelect msSqlSelect = new MsSqlSelect();

            TestModel test = new TestModel("table");

            test.Age = 35;
            test.Height = 100;
            test.City = "Hiroshima";

            test.SetSelect("age", SelectClause.Equal);
            test.SetSelect("height", SelectClause.NotEqual);
            test.SetSelect("city", SelectClause.Like);
 
            var postgresSqlQuery = postgreSqlSelect.GetQuery(test);
            var msSqlQuery = msSqlSelect.GetQuery(test);

            var partialQuery = TmpQuery.Substring(TmpQuery.LastIndexOf(SubstringKeyword));
            var postgrePartialQuery = postgresSqlQuery.Substring(postgresSqlQuery.LastIndexOf(SubstringKeyword));
            var msPartialQuery = msSqlQuery.Substring(msSqlQuery.LastIndexOf(SubstringKeyword));


            Assert.AreEqual(postgrePartialQuery,partialQuery);
            Assert.AreEqual(msPartialQuery, partialQuery);

            //Assert.AreEqual("SELECT age,height,city FROM table WHERE age = 35 AND height != 100 AND city LIKE 'Hiroshima'", res);
            //Assert.AreEqual("SELECT city FROM table", res);
        }
    }
}

