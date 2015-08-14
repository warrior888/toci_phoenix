using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.BusinessModels.DevelopersList;
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
            List<portfolio> userPortfolioFromDb = FetchModelsFromDb<portfolio>(new portfolio()
            {
                FkIdUsers = userId
            }.SetSelect("fk_id_users", SelectClause.Equal));

            return userPortfolioFromDb.Select(portfolio => new PortfolioBusinessModel()
            {
                ProjectName = portfolio.ProjectName
            }).Cast<IPortfolioBusinessModel>().ToList();
        }
    }
}