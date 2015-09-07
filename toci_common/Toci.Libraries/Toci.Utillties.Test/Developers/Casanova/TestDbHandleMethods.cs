using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace Toci.Utilities.Test.Developers.Casanova
{
    [TestClass]
    public class TestDbHandleMethods
    {
        const string IMIE = "randomName";
        const string NAZWISKO = "randomSurname";
        const int WIEK = 10;
        const string NAME_NAME = "imie";
        const string SURNAME_NAME = "nazwisko";
        const string AGE_NAME = "wiek";

        private TestModel model;
        private DbHandle dbh;

        public TestDbHandleMethods()
        {
            dbh = new DbHandle(new PostgreSqlClient("postgres", "zaq1@WSX", "localhost", "postgres"), new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete());

            model = new TestModel("table1");
            model.AddIsWhere(NAME_NAME, "aaa", true);
            model.AddIsWhere(SURNAME_NAME, NAZWISKO, true);
            model.AddIsWhere(AGE_NAME, WIEK, false);
        }

        [TestMethod]
        public void DbTest()
        {
            dbh.InsertData(model);
            model.setName(IMIE);
            dbh.InsertData(model);

            var array = GetLastArrayFromDb(dbh);
            Assert.AreEqual(IMIE, array[0]);
            Assert.AreEqual(NAZWISKO, array[1]);
            Assert.AreEqual(WIEK, array[2]);

            int newAge = 13;
            model.setAge(newAge);
            dbh.UpdateData(model);

            Assert.AreEqual(newAge, GetLastArrayFromDb(dbh)[2]);

            dbh.DeleteData(model);

            model.setName("aaa");

            Assert.AreEqual(WIEK, GetLastArrayFromDb(dbh)[2]);
        }

        private List<Object> GetLastArrayFromDb(DbHandle dbh)
        {
            var dataSet = dbh.GetData(model);
            var tables = dataSet.Tables;
            var rows = tables[tables.Count - 1].Rows;
            if (rows.Count == 0)
                return null;
            return rows[rows.Count - 1].ItemArray.ToList();
        }
    }
}
