using System;
using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class TeamLeasingLogic : DbLogic, ITeamLeasingLogic
    {

        //DI
        IDeveloperListLogic _developersLogic = new DeveloperListLogic();

        public IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams)
        {
            List<portfolio> portfolios = FetchModelsFromDb<portfolio>(new portfolio());

            List<IDeveloperBusinessModel> developers = portfolios.Select
                                                    (portfolio => _developersLogic.GetDevByUserId(portfolio.FkIdUsers)).ToList();
            return null;
        }

        public void RentTeam(IDeveloperTeamBusinessModel developerTeam)
        {
            throw new NotImplementedException();
        } 
    }
}