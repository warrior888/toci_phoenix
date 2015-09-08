using System;
using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class TeamLeasingLogic : PhoenixDataAccessLogic, ITeamLeasingLogic
    {

        private readonly IDeveloperListLogic _developersLogic;
        private readonly IPortfolioLogic _portfolioLogic;

        public TeamLeasingLogic(IDeveloperListLogic developerListLogic, IPortfolioLogic portfolioLogic)
        {
            _developersLogic = developerListLogic;
            _portfolioLogic = portfolioLogic;
        }

        public IEnumerable<IDeveloperTeamBusinessModel> GetAllTeams()
        {
            List<portfolio> portfolio = FetchModelsFromDb<portfolio>(new portfolio());

            List<IDeveloperBusinessModel> teamsLeaders = portfolio.Select(p => _portfolioLogic.GetProjectTeamLeader(p.Id))
                                                                  .Distinct().ToList();
            List<IDeveloperTeamBusinessModel> teams = teamsLeaders.Select(GetTeamByTeamLeader).ToList();
            return teams;
        }

        public IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams)
        {
            return null;
        }

        public void RentTeam(IDeveloperTeamBusinessModel developerTeam)
        {
            
        }

        private IDeveloperTeamBusinessModel GetTeamByTeamLeader(IDeveloperBusinessModel teamLeader)
        {
            List<List<IDeveloperBusinessModel>> projectDevelopers = new List<List<IDeveloperBusinessModel>>();
            List<IPortfolioBusinessModel> leadProjects =  teamLeader.Portfolio.Where(portfolio => portfolio.TeamLeaderId == teamLeader.User.Id).ToList();
            leadProjects.ForEach(portfolio => projectDevelopers.Add(_portfolioLogic.GetProjectDevelopers(portfolio.Id).ToList()));
            List<double> teamScores = projectDevelopers.Select(team => team.Sum(dev => dev.Score)).ToList();

            int indexOfBestTeam = teamScores.IndexOf(teamScores.Max());

            return new DeveloperTeamBusinessModel()
            {
                TeamLeader = teamLeader,
                TeamMembers = projectDevelopers[indexOfBestTeam],
                TeamPortfolio = _portfolioLogic.GetTeamProjects(projectDevelopers[indexOfBestTeam])
            };
        }

        
    }
}