using System;
using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.BusinessModels.TeamLeasing;
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
        private IDeveloperListLogic _developersLogic;
        private IPortfolioLogic _portfolioLogic;

        public TeamLeasingLogic(IDeveloperListLogic DeveloperListLogic, IPortfolioLogic PortfolioLogic)
        {
            _developersLogic = DeveloperListLogic;
            _portfolioLogic = PortfolioLogic;
        }

        public IEnumerable<IDeveloperTeamBusinessModel> GetAllTeams()
        {
            List<portfolio> portfolio = FetchModelsFromDb<portfolio>(new portfolio());
            return null;
        }

        public IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams)
        {
            List<portfolio> portfolio = FetchModelsFromDb<portfolio>(new portfolio());

            List<IDeveloperBusinessModel> developers = portfolio.Select
                                                    (p => _developersLogic.GetDevByUserId(p.FkIdUsers)).ToList();
            
            IDeveloperTeamBusinessModel developersTeam = new DeveloperTeamBusinessModel()
            {
                
            };
            return null;
        }

        public void RentTeam(IDeveloperTeamBusinessModel developerTeam)
        {
            throw new NotImplementedException();
        }

        private IDeveloperTeamBusinessModel GetTeam()
        {
            return null;
        }
    }
}