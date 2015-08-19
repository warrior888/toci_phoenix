﻿using System;
using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class TeamLeasingLogic : DataAccessLogic, ITeamLeasingLogic
    {

        //DI
        private IDeveloperListLogic _developersLogic;
        private IPortfolioLogic _portfolioLogic;

        public TeamLeasingLogic(IDeveloperListLogic DeveloperListLogic, IPortfolioLogic PortfolioLogic)
        {
            _developersLogic = DeveloperListLogic;
            _portfolioLogic = PortfolioLogic;
        }

        //TODO
        public IEnumerable<IDeveloperTeamBusinessModel> GetAllTeams()
        {
            var teamsList = new List<IDeveloperTeamBusinessModel>();

            var devsList = _developersLogic.GetAllDevelopers().ToList();
            var projectsList = _portfolioLogic.GetAllProjects().ToList();

            projectsList.ForEach(project => teamsList.Add(new DeveloperTeamBusinessModel()));

            foreach (var project in projectsList)
            {
                teamsList.Add(new DeveloperTeamBusinessModel()
                {
                    TeamLeader = _portfolioLogic.GetProjectTeamLeader(project.Id),
                    
                 
                });
            }
            

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