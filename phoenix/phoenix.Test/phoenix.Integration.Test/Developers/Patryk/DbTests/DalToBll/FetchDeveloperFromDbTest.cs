using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Integration.Test.Developers.Patryk.DbTests.DalToBll
{
    [TestClass]
    public class FetchDeveloperFromDbTest
    {
        [TestMethod]
        public void TryFetchDeveloperSkillsFromDb()
        {
            ModelLogic modelLogic = new ModelLogic();
            List<developers_skills> developersSkills = modelLogic.GetModelFromDbTest<developers_skills>(new developers_skills());
        }
         
    }
}