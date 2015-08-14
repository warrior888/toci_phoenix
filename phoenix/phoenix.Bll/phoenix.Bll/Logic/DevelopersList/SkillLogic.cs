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
            var all = GetAllElements<ISkillBusinessModel, skills_view>();

            foreach (var skill in  all)
            {
                
            }

            return null;
        }
    }
}