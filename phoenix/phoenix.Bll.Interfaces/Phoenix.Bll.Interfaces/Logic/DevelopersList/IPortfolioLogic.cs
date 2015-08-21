using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IPortfolioLogic
    {
        IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId);

        IDeveloperBusinessModel GetProjectTeamLeader(int portfolioId);
        
        IEnumerable<IDeveloperBusinessModel> GetProjectDevelopers(int portfolioId);

        IEnumerable<IPortfolioBusinessModel> GetTeamProjects(List<IDeveloperBusinessModel> team);
            
        IEnumerable<IPortfolioBusinessModel> GetAllProjects();
    }
}