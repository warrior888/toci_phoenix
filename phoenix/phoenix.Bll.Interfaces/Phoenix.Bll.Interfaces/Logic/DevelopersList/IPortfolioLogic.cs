using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IPortfolioLogic
    {
        IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId);

        IDeveloperBusinessModel GetProjectTeamLeader(int portfolioId);

        IEnumerable<IPortfolioBusinessModel> GetAllProjects();
    }
}