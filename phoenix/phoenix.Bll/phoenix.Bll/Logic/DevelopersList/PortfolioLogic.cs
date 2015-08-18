using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using AutoMapper;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class PortfolioLogic : DbLogic, IPortfolioLogic
    {
        private ISkillLogic _skillLogic;

        public PortfolioLogic()
        {
            _skillLogic = new SkillLogic();

        }

        public IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId)
        {
            List<users_portfolio> userPortfolioFromDb = FetchModelsByColumnValue<users_portfolio, int>("id_users",
                SelectClause.Equal, userId);

            List<IPortfolioBusinessModel> userPortfolio =
                userPortfolioFromDb.Select(portfolio => GetPortfolioById(portfolio.Id)).ToList();

            return userPortfolio;

        }

        public IPortfolioBusinessModel GetPortfolioById(int portfolioId)
        {
            return Mapper.Map<IPortfolioBusinessModel>(FetchModelById<portfolio>(portfolioId));
        } 
    }
}