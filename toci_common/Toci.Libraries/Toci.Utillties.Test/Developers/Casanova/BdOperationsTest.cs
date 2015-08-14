using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace Toci.Utilities.Test.Developers.Casanova
{
    [TestClass]
    public class BdOperationsTest
    {
        [TestMethod]
        public void PostgreSqlUpdate()
        {
            PostgreSqlUpdate postgresUpdate = new PostgreSqlUpdate();
            TestModel tm = new TestModel("table1");
            tm.AddIsWhere("imie", "Jan", true);
            tm.AddIsWhere("nazwisko", "Kowalski", true);
            tm.AddIsWhere("wiek", 50, false);
            tm.AddIsWhere("var1", 100, false);

            var res = postgresUpdate.GetQuery(tm);

            Assert.AreEqual("UPDATE table1 SET imie = 'Jan', nazwisko = 'Kowalski', wiek = 50, var1 = 100 WHERE imie = 'Jan' AND nazwisko = 'Kowalski';", res);
        }
    }
}
