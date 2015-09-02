using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace Toci.Utilities.Test.Developers.Casanova
{
    [TestClass]
    public class BdOperationsTest
    {
        private const string UpdateQuery = "UPDATE table1 SET imie = 'Jan', nazwisko = 'Kowalski', wiek = 50, var1 = 100 WHERE imie = 'Jan' AND nazwisko = 'Kowalski';";
        private TestModel _tm;

        [TestMethod]
        public void PostgreSqlUpdate()
        {
            PostgreSqlUpdate postgresUpdate = new PostgreSqlUpdate();
            PrepareModel();

            var res = postgresUpdate.GetQuery(_tm);

            Assert.AreEqual(UpdateQuery, res);
        }

        [TestMethod]
        public void MsSqlUpdate()
        {
            MsSqlUpdate msUpdate = new MsSqlUpdate();
            PrepareModel();

            var res = msUpdate.GetQuery(_tm);

            Assert.AreEqual(UpdateQuery, res);
        }

        private void PrepareModel()
        {
            _tm = new TestModel("table1");
            _tm.AddIsWhere("imie", "Jan", true);
            _tm.AddIsWhere("nazwisko", "Kowalski", true);
            _tm.AddIsWhere("wiek", 50, false);
            _tm.AddIsWhere("var1", 100, false);
        }
    }
}
