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


            DbProjectsModel model = new DbProjectsModel{ ProjectID = 1, ProjectData = "kupczon", ScopeID = 1, ProjectName = "Tralala"};

            dbQuery.Save(model, "Projects");
            var result = dbQuery.Load("Projects");
            //Assert.AreEqual(testString, r);
        }
    }
}