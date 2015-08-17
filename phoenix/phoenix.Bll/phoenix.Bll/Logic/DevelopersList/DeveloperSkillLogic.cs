using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class DeveloperSkillLogic : DbLogic,IDeveloperSkillLogic
    {
        public IEnumerable<IDeveloperSkillBusinessModel> GetUserSkills(int userId)
        {
            /*var allSkills = GetAllElements<ISkillBusinessModel, skills_view>(dest => dest.SkillName, opt => opt.MapFrom(src => src.TechName));

            List<ISkillBusinessModel> userSkillsList = allSkills.Where(skill => skill.IdUsers == userId).ToList();

            return userSkillsList;*/

            List<developers_skills> developersSkills= FetchModelsByColumnValue<developers_skills, int>
                ("id_users", SelectClause.Equal, userId);

            List<IDeveloperSkillBusinessModel> skills =
                developersSkills.Select(skill => GetSkillById(skill.IdSkillsTechnologies)).ToList();

            return skills;
        }

        public IEnumerable<IDeveloperSkillBusinessModel> GetPortfolioSkills(int portfolioId)
        {
            List<portfolio_skills_technologies> portfolioSkills = FetchModelsByColumnValue<portfolio_skills_technologies, int>
                ("fk_id_portfolio", SelectClause.Equal, portfolioId);
            List<IDeveloperSkillBusinessModel> skills = 
                portfolioSkills.Select(skill => GetSkillById(skill.FkIdSkillsTechnologies)).ToList();

            return skills;
        }

        public IDeveloperSkillBusinessModel GetSkillById(int skillId)
        {
            return Mapper.Map<IDeveloperSkillBusinessModel>( FetchModelById<skills_technologies>(skillId) );
        }
    }
}