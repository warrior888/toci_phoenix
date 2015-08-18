using System;
using DbCrypting;
using DbCrypting.VazcoDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Tests
{
    [TestClass]
    public class DbCryptingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbOperator = new DbOperations("dupa");
            const string testString = "Test rwerwerw";

            var model = new VazcoTable {data = testString,name = "TestName"};

            dbOperator.Save(model);

            var result = dbOperator.Load();
            Assert.AreEqual(testString,result[0].data);
        }

        [TestMethod]
        public void DeleteTest()
        {
            //var dbSave = new DbSave();
           // var dbLoad = new DbLoad();
           var dbo = new DbOperations("dupa");
            var result = dbo.Load();

            var model = new VazcoTable() { id = 4 };

            dbo.Delete(model);
            var result2 = dbo.Load();
            Assert.AreEqual(result.Count-1,result2.Count);

        }

        [TestMethod]
        public void UpdateTest()
        {
            //var dbSave = new DbSave();
           // var dbLoad = new DbLoad();
           var dbo = new DbOperations("dupa");
            const string testString = "ValueToUpdate";
            const string updatedString = "UpdatedValue";


            var model = new VazcoTable() { data = testString };

            dbo.Save(model);
            var result = dbo.Load();
            var model2 = new VazcoTable()
            {
                addingTime = result[0].addingTime,
                data = updatedString,
                name = result[0].name,
                id = result[0].id
            };

            dbo.Update(model2);
            var result2 = dbo.Load();


            Assert.AreEqual(updatedString, result2[0].data);


        }
    }
}
