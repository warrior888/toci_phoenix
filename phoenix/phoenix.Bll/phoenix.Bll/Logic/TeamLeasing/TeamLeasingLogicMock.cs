using System;
using System.Collections.Generic;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
//using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class TeamLeasingLogicMock : DataAccessLogic, ITeamLeasingLogic
    {
        public IEnumerable<IDeveloperTeamBusinessModel> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams)
        {
            List<DeveloperBusinessModel> devList = new List<DeveloperBusinessModel>()
            {
                new DeveloperBusinessModel()
                {
                    DeveloperAvailable =
                        new DeveloperAvailableBusinessModel()
                        {
                            AvailableFor = new DateTime(2015, 8, 27),
                            EndWorkHour = 16,
                            StartWorkHour = 8
                        },
                    ExperienceFrom = new DateTime(2015, 5, 5),
                  /*  Name = "Zdzislaw",
                    Surname = "Nowak",
                    Nick = "M4s4kr4t0r",*/
                    Portfolio = new List<PortfolioBusinessModel>
                    {
                        new PortfolioBusinessModel()
                        { 
                            EndDate = new DateTime(2015, 6, 7),
                            ProjectName = "phoenix",
                        }
                    }

                },

                new DeveloperBusinessModel()
                {
                    DeveloperAvailable =
                        new DeveloperAvailableBusinessModel()
                        {
                            AvailableFor = new DateTime(2015, 8, 27),
                            EndWorkHour = 16,
                            StartWorkHour = 8
                        },
                    ExperienceFrom = new DateTime(2012, 3, 1),
                   /* Name = "Jan",
                    Surname = "Kowalski",
                    Nick = "kowal",*/
                    Portfolio = new List<PortfolioBusinessModel>
                    {
                        new PortfolioBusinessModel()
                        {
                            EndDate = new DateTime(2015, 6, 7),
                            ProjectName = "phoenix",
                        }
                    }

                }
            };
            DeveloperTeamBusinessModel devTeam = new DeveloperTeamBusinessModel()
            {
                TeamLeader = devList[0],
                TeamMembers = devList,
                TeamPortfolio = new List<IPortfolioBusinessModel>()
                {
                    new PortfolioBusinessModel()
                    {
                         EndDate = new DateTime(2015, 6, 7),
                            ProjectName = "phoenix",
                    }, 
                    new PortfolioBusinessModel()
                    {
                         EndDate = new DateTime(2012, 2, 1),
                         ProjectName = "whatever",
                    }
                }
            };


            List<DeveloperTeamBusinessModel> returnList = new List<DeveloperTeamBusinessModel>
            {
                devTeam
            };
            return returnList;
        }

        public void RentTeam(IDeveloperTeamBusinessModel developerTeam)
        {
            //var test = developerTeam.TeamLeader.Nick;
        }
    }
}