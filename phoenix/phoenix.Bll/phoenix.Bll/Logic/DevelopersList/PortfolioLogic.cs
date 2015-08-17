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
        private ISkillLogic _skillLogic = new SkillLogic();

        public IEnumerable<IPortfolioBusinessModel> GetUserPortfolio(int userId)
        {
            List<IPortfolioBusinessModel> portfolioList = new List<IPortfolioBusinessModel>();

            var models = FetchModelsFromDb<portfolio>(new portfolio());
            var allPortfolios = GetAllElements<IPortfolioBusinessModel, portfolio>(dest => dest.EndDate, opt => opt.MapFrom(src => src.ProjectCompletionDate));

          var x =  Mapper.CreateMap<IPortfolioBusinessModel, portfolio>();
            return null;
        }
    }
}