using System;
using System.Collections.Generic;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.UsersList;
using Phoenix.Bll.Logic.TeamLeasing;
using Phoenix.Bll.Logic.UsersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class DeveloperListLogic : DbLogic, IDeveloperListLogic
    {

        //TODO DI + widok
        IUsersLogic _userLogic = new UsersLogic();
        IPortfolioLogic _portfolioLogic = new PortfolioLogic();
        ISkillLogic _skillLogic = new SkillLogic();
        IDeveloperAvailableLogic _availableLogic = new DeveloperAvailableLogic();
        
        public IDeveloperBusinessModel GetDevById(int id)
        {
            IDeveloperBusinessModel developer = new DeveloperBusinessModel();

            developers_list developerToDb = new developers_list()
            {
                IdUsers = id
            };
            developerToDb.SetSelect("id_users", SelectClause.Equal);
            developers_list developerFromDb = FetchModelFromDb<developers_list>(developerToDb);
            developer.User = _userLogic.GetUserById(developerFromDb.IdUsers);
            developer.ExperienceFrom = developerFromDb.ExperienceFrom;
            developer.Portfolio = _portfolioLogic.GetUserPortfolio(developerFromDb.IdUsers);
            developer.Skills = _skillLogic.GetUserSkills(developerFromDb.IdUsers);
            developer.DeveloperAvailable = _availableLogic.GetDeveloperAvailableById(developerFromDb.FkIdDevelopersAvaible);
            return developer;

        }

        public IEnumerable<IDeveloperBusinessModel> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

    }
}