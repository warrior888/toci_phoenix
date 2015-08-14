using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IPortfolioLogic
    {
        IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId);
    }
}