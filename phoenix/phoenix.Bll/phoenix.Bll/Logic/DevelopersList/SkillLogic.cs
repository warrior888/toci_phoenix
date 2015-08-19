using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class SkillLogic : DataAccessLogic, ISkillLogic
    {
        public IEnumerable<IDeveloperSkillBusinessModel> GetDeveloperSkills(int userId)
        {
            return GetElementsByColumnValue<IDeveloperSkillBusinessModel, developer_skills_view, int>("id_users",
                    SelectClause.Equal, userId);
        }

        public IEnumerable<ISkillBusinessModel> GetPortfolioSkills(int portfolioId)
        {
            List<portfolio_skills_technologies> portfolioSkills = FetchModelsByColumnValue<portfolio_skills_technologies, int>
                ("fk_id_portfolio", SelectClause.Equal, portfolioId);
            return portfolioSkills.Select(skill => GetSkillById(skill.FkIdSkillsTechnologies)).ToList();
        }

        public ISkillBusinessModel GetSkillById(int skillId)
        {
            return GetElementById<ISkillBusinessModel, skills_technologies>(skillId);
        }
    }
}