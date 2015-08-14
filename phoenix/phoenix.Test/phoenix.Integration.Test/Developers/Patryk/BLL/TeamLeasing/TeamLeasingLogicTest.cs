using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            ITeamLeasingLogic teamLeasingLogic = new TeamLeasingLogic();
            ITeamLeasingBusinessModel teamLeasingBusinessModel = new TeamLeasingBusinessModel()
            {
                SkillSet = new List<ISkillBusinessModel>()
                {
                    new SkillBusinessModel()
                    {
                        SkillLevel = 20,
                        SkillName = "C#"
                    }
                }
            };
            teamLeasingLogic.GetTeams(teamLeasingBusinessModel, 5);
        }

        [TestMethod]
        public void GetDevById()
        {
            IDeveloperListLogic developerLogic = new DeveloperListLogic();
            IDeveloperBusinessModel developer = developerLogic.GetDevById(2);
            IDeveloperBusinessModel developer1 = developerLogic.GetDevById(3);
            IDeveloperBusinessModel developer2 = developerLogic.GetDevById(5);
            IDeveloperBusinessModel developer3 = developerLogic.GetDevById(6);
        }
         
    }
}