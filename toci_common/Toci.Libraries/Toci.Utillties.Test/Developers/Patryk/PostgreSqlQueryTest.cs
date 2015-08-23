using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.DbVirtualization;
using Toci.Db.DbVirtualization.PostgreSqlQuery;
using Toci.Db.Interfaces;
using Toci.Utilities.Test.Developers.Kielich;

namespace Toci.Utilities.Test.Developers.Patryk
{
    [TestClass]
    public class PostgreSqlQueryTest
    {
        private readonly TestModel _testModelWithWhere;
        private readonly TestModel _testModelWithoutWhere;

        public PostgreSqlQueryTest()
        {
            _testModelWithWhere = new TestModel("table")
            {
                Age = 35,
                Height = 180,
                City = "Lubań"
            };
            
            _testModelWithWhere.SetSelect("age", SelectClause.Equal, 20);
            _testModelWithWhere.SetSelect("height", SelectClause.NotEqual, 170);
            _testModelWithWhere.SetSelect("city", SelectClause.Like, "Lub");

            _testModelWithoutWhere = new TestModel("table");


        }

        [TestMethod]
        public void PostgreSqlSelectTest()
        {
            ISelect postgreSqlSelect = new PostgreSqlSelect();
            string queryWithWhere = postgreSqlSelect.GetQuery(_testModelWithWhere);

            //TODO poprawic generator tak, aby nazwy kolumn były od razu dostępne
            Assert.AreEqual(queryWithWhere, "SELECT * FROM table WHERE age = 20 AND height != 170 AND city LIKE 'Lub';");

            string queryWitoutWhere = postgreSqlSelect.GetQuery(_testModelWithoutWhere);
            Assert.AreEqual(queryWitoutWhere, "SELECT * FROM table;");

        }
        
        [TestMethod]
        public void PostgreSqlInsertTest()
        {
            IInsert postgreSqlInsert = new PostgreSqlInsert();

            string queryWitoutWhere = postgreSqlInsert.GetQuery(_testModelWithWhere);
            Assert.AreEqual(queryWitoutWhere, "insert into table (age,height,city) values (35,180,'Lubań');");
        }

        [TestMethod]
        public void PostgreSqlUptadeTest()
        {
            IUpdate postgreSqlUpdate = new PostgreSqlUpdate();

            string queryWithWhere = postgreSqlUpdate.GetQuery(_testModelWithWhere);
            Assert.AreEqual(queryWithWhere, "UPDATE table SET age = 35, height = 180, city = 'Lubań' WHERE age = 20 AND height != 170 AND city LIKE 'Lub';");

            string queryWithoutWhere = postgreSqlUpdate.GetQuery(_testModelWithoutWhere);
            Assert.AreEqual(queryWithoutWhere, "");
        }

        [TestMethod]
        public void PostgreSqlDeleteTest()
        {
            IDelete postgreSqlDelete = new PostgreSqlDelete();
            string queryWithWhere = postgreSqlDelete.GetQuery(_testModelWithWhere);
            Assert.AreEqual(queryWithWhere, "DELETE FROM table WHERE age = 20 AND height != 170 AND city LIKE 'Lub';");

            string queryWitouthWhere = postgreSqlDelete.GetQuery(_testModelWithoutWhere);
            Assert.AreEqual(queryWitouthWhere, "DELETE FROM table;");
        }

        [TestMethod]
        public void SetSelectDontChangeFieldValueTest()
        {
            Assert.AreEqual(_testModelWithWhere.Age,35);
            Assert.AreEqual(_testModelWithWhere.Height,180);
            Assert.AreEqual(_testModelWithWhere.City,"Lubań");
            
        }
         
    }
}