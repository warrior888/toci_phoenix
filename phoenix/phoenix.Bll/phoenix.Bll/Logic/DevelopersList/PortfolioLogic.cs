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
            portfolio userPortfolioToDb = new portfolio()
            {
                FkIdUsers = userId
            };
            userPortfolioToDb.SetSelect("fk_id_users", SelectClause.Equal);
            List<portfolio> userPortfolioFromDb = FetchModelsFromDb<portfolio>(userPortfolioToDb);

            return userPortfolioFromDb.Select(portfolio => new PortfolioBusinessModel()
            {
                ProjectName = portfolio.ProjectName
            }).Cast<IPortfolioBusinessModel>().ToList();
        }
    }
}