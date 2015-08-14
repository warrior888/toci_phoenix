using System.Collections.Generic;
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
            ISkillBusinessModel skillBusinessModel = new SkillBusinessModel();
            //List<portfolio> userPortfolioFromDb = ConvertDataSetToModels<portfolio>(userPortfolioToDb);
            return null;
        }
    }
}