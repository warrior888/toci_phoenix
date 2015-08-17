using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Bll.Logic.TeamLeasing;

namespace Phoenix.Integration.Test.Developers.Patryk.BLL.TeamLeasing
{
    [TestClass]
    public class TeamLeasingLogicTest
    {
        [TestMethod]
        public void TryGetDataFromDb()
        {
            AutoMapperConfiguration.Configure();

            IDeveloperListLogic developerListLogic= new DeveloperListLogic();
            developerListLogic.GetDevById(1);

            ITeamLeasingLogic teamLeasingLogic = new TeamLeasingLogic();
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
        }         
    }
}