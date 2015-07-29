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
            var dbSave = new DbSave();
            var dbLoad = new DbLoad();
            const string testString = "Rabarbarrrr";


            var model = new DbModel() {data = testString};

            dbSave.Save(model);
            var result = dbLoad.Load();
            Assert.AreEqual(testString,result[0].data);
        }
    }
}
