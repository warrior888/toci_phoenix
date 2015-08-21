using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class PortfolioLogic : DataAccessLogic, IPortfolioLogic
    {
        private const string UserIdLabel = "id_users";
        private const string PortfolioLabel = "id_portfolio";
   
        private readonly IDeveloperListLogic _developerListLogic;

        public PortfolioLogic(IDeveloperListLogic developerListLogic)
        {
            _developerListLogic = developerListLogic;
        }

        public IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId)
        {
            List<users_portfolio> userPortfolio = FetchModelsByColumnValue<users_portfolio, int>(UserIdLabel,
                SelectClause.Equal, userId);
            return userPortfolio.Select(p => GetElementById<IPortfolioBusinessModel, portfolio>(p.IdPortfolio)).ToList();
        }

        public IDeveloperBusinessModel GetProjectTeamLeader(int portfolioId)
        {
            portfolio portfolio = FetchModelById<portfolio>(portfolioId);
            return _developerListLogic.GetDevByUserId(portfolio.TeamLeaderId);
        }

        public IEnumerable<IDeveloperBusinessModel> GetProjectDevelopers(int portfolioId)
        {
            List<users_portfolio> userPortfolio = FetchModelsByColumnValue<users_portfolio, int>(PortfolioLabel,
                SelectClause.Equal, portfolioId);
            return userPortfolio.Select(portfolio => _developerListLogic.GetDevByUserId(portfolio.IdUsers));
        }

        //TODO zmiana get all project na np get project by dev id, zwrocenie projektu jezeli braly w nim udzial np 3 osoby 
        public IEnumerable<IPortfolioBusinessModel> GetTeamProjects(List<IDeveloperBusinessModel> team)
        {
            List<IPortfolioBusinessModel> portfolios = GetAllProjects().ToList();
            List<IPortfolioBusinessModel> teamPortfolios =
                portfolios.Where(portfolio => team.All(dev => dev.Portfolio.Any(p => p.Id == portfolio.Id))).ToList();
            return teamPortfolios;
        } 

        public IEnumerable<IPortfolioBusinessModel> GetAllProjects()
        {
            return GetAllElements<IPortfolioBusinessModel, portfolio>();
        }
    }
}