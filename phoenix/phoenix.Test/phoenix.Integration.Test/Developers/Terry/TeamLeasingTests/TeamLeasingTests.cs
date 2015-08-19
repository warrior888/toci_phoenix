using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Essential;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.TeamLeasing;

namespace Phoenix.Integration.Test.Developers.Terry.TeamLeasingTests
{
    [TestClass]
    public class TeamLeasingTests
    {
        [TestMethod]
        public void TeamLeasingBusinessLogicMockTest()
        {
            AutofacDependencyResolver resolver = new AutofacDependencyResolver();

            var logic = resolver.Resolve<ITeamLeasingLogic>();

            var teams = logic.GetAllTeams();

        }
}
}
