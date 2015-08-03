using DbCredentials.Logic;
using DbCredentials.Logic.DbModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Tests
{
    [TestClass]
    public class DbCredentials
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbQuery = new DbQuery();
            const string testString = "Test text";


            DbScopesModel model = new DbScopesModel { ScopeID = 1, ScopeName = "Tralala" };

            dbQuery.Save(model, "Scopes");
            var result = dbQuery.Load("Scopes");
            //Assert.AreEqual(testString, r);
        }
    }
}