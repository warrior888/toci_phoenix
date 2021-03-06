﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Essential;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
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

            var mapper = resolver.Resolve<AutoMapperConfiguration>();
            var logic = resolver.Resolve<ITeamLeasingLogic>();
            var logicAvailable = resolver.Resolve<IDeveloperAvailableLogic>();
            var logicDev = resolver.Resolve<IDeveloperListLogic>();

         //   var devTest = logicDev.GetDevByUserId(3);
            var test = logicAvailable.GetDeveloperAvailableById(18);
            //var devs = logic.GetAllTeams();

        }
}
}
