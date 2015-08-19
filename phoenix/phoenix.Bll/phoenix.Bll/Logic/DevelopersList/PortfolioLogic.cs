using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class PortfolioLogic : DbLogic, IPortfolioLogic
    {
        public IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId)
        {
            List<users_portfolio> userPortfolio = FetchModelsByColumnValue<users_portfolio, int>("id_users",
                SelectClause.Equal, userId);
            return userPortfolio.Select(p => GetElementById<IPortfolioBusinessModel, portfolio>(p.IdPortfolio)).ToList();
        }

        public IDeveloperBusinessModel GetProjectTeamLeader(int portfolioId)
        {
            portfolio portfolio = FetchModelById<portfolio>(portfolioId);
            return GetElementById<IDeveloperBusinessModel, developer_list_view>(portfolio.FkIdUsers);
        }
    }
}