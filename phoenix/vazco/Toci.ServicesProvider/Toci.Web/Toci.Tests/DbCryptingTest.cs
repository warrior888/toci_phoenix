using System;
using DbCrypting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Tests
{
    [TestClass]
    public class DbCryptingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbOperator = new DbOperations();
            const string testString = "Test text";

            var model = new VazcoTable {data = testString};

            dbOperator.Save(model);

            var result = dbOperator.Load();
            Assert.AreEqual(testString,result[0].data);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var dbSave = new DbSave();
            var dbLoad = new DbLoad();
            var result = dbLoad.Load();

            var model = new DbModel() { id = 2 };

            dbSave.Delete(model);
            var result2 = dbLoad.Load();
            Assert.AreEqual(result.Count-1,result2.Count);

        }

        [TestMethod]
        public void UpdateTest()
        {
            var dbSave = new DbSave();
            var dbLoad = new DbLoad();
            const string testString = "ValueToUpdate";
            const string updatedString = "UpdatedValue";


            var model = new DbModel() { data = testString };

            dbSave.Save(model);
            var result = dbLoad.Load();
            var model2 = new DbModel()
            {
                addingTime = result[0].addingTime,
                data = updatedString,
                nick = result[0].nick
            };

            dbSave.Update(model2);
            var result2 = dbLoad.Load();


            Assert.AreEqual(updatedString, result[0].data);


        }
    }
}
