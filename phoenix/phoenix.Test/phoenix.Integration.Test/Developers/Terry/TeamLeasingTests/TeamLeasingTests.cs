using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Logic.TeamLeasing;

namespace Phoenix.Integration.Test.Developers.Terry.TeamLeasingTests
{
    [TestClass]
    public class TeamLeasingTests
    {
        [TestMethod]
        public void TeamLeasingBusinessLogicMockTest()
        {
            TeamLeasingBusinessModel lease = new TeamLeasingBusinessModel();

            TeamLeasingLogicMock logic = new TeamLeasingLogicMock();

            var result = logic.GetTeams(lease, 1);

        }
}
}
