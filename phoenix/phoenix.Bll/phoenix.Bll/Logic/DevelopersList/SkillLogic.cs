using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.Essential;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class SkillLogic : DataAccessLogic, ISkillLogic
    {
        private const string UserIdLabel = "id_users";
        private const string PortfolioIdLabel = "fk_id_portfolio";

        public IEnumerable<IDeveloperSkillBusinessModel> GetDeveloperSkills(int userId)
        {
            return GetElementsByColumnValue<IDeveloperSkillBusinessModel, developer_skills_view, int>(UserIdLabel,
                    SelectClause.Equal, userId);
        }

        public IEnumerable<ISkillBusinessModel> GetPortfolioSkills(int portfolioId)
        {
            List<portfolio_skills_technologies> portfolioSkills = FetchModelsByColumnValue<portfolio_skills_technologies, int>
                (PortfolioIdLabel, SelectClause.Equal, portfolioId);
            return portfolioSkills.Select(skill => GetSkillById(skill.FkIdSkillsTechnologies)).ToList();
        }

        public ISkillBusinessModel GetSkillById(int skillId)
        {
            return GetElementById<ISkillBusinessModel, skills_technologies>(skillId);
        }

        public IEnumerable<ISkillBusinessModel> GetAllSkills()
        {   
            
            /***** na potrzeby testow, zanim zrobie DI na forncie *******/
                AutofacDependencyResolver resolver = new AutofacDependencyResolver();
                var mapper = resolver.Resolve<AutoMapperConfiguration>();
           
            return GetAllElements<ISkillBusinessModel, skills_technologies>();
        } 
    }
}