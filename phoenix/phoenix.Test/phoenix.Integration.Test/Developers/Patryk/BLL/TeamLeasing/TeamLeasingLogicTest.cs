using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Essential;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Bll.Logic.TeamLeasing;
using Toci.Utilities.Interfaces.DependencyResolve;

namespace Phoenix.Integration.Test.Developers.Patryk.BLL.TeamLeasing
{
    [TestClass]
    public class TeamLeasingLogicTest
    {
        [TestMethod]
        public void TryGetDataFromDb()
        {
            IDependencyResolver dependencyResolver = new DependencyResolverFactory().Create(DependencyResolverType.Autofac);

            AutoMapperConfiguration configuration = dependencyResolver.Resolve<AutoMapperConfiguration>();

            configuration.Configure();

            IDeveloperListLogic developerListLogic = dependencyResolver.Resolve<IDeveloperListLogic>();
            developerListLogic.GetDevByUserId(19);

            //ITeamLeasingLogic teamLeasingLogic = new TeamLeasingLogic(dependencyResolver.Resolve<IDeveloperListLogic>(), dependencyResolver.Resolve<IPortfolioLogic>());
            ITeamLeasingLogic teamLeasingLogic = new TeamLeasingLogic(new DeveloperListLogic(), new PortfolioLogic(new DeveloperListLogic()));
            ITeamLeasingBusinessModel teamLeasingBusinessModel = new TeamLeasingBusinessModel()
            {
                SkillSet = new List<IDeveloperSkillBusinessModel>()
                {
                    new DeveloperSkillBusinessModel()
                    {
                        
                        SkillLevel = 20,
                        SkillName = "C#"
                    }
                }
            };
            teamLeasingLogic.GetTeams(teamLeasingBusinessModel, 5);
            
            teamLeasingLogic.GetAllTeams();
        }


        [TestMethod]
        public void BusinessLogicTest()
        {
            IPortfolioLogic portfolioLogic = new PortfolioLogic(new DeveloperListLogic());
            portfolioLogic.GetAllProjects(); 
        }
    }
}