using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface ISkillLogic
    {
        IEnumerable<ISkillBusinessModel> GetUserSkills(int userId);

        IEnumerable<ISkillBusinessModel> GetPortfolioSkills(int portfolioId);
    }
}