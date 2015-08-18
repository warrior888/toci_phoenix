using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface ISkillLogic
    {
        IEnumerable<ISkillBusinessModel> GetDeveloperSkills(int userId);

        IEnumerable<ISkillBusinessModel> GetPortfolioSkills(int portfolioId);

        ISkillBusinessModel GetSkillById(int skillId);
    }
}