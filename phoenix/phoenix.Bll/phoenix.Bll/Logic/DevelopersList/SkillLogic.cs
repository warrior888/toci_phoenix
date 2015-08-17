using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.DevelopersList
{
    public class SkillLogic : DbLogic,ISkillLogic
    {
        public IEnumerable<ISkillBusinessModel> GetUserSkills(int userId)
        {
            var allSkills = GetAllElements<ISkillBusinessModel, skills_view>(dest => dest.SkillName, opt => opt.MapFrom(src => src.TechName));

            List<ISkillBusinessModel> userSkillsList = allSkills.Where(skill => skill.IdUsers == userId).ToList();

            return userSkillsList;
        }
    }
}