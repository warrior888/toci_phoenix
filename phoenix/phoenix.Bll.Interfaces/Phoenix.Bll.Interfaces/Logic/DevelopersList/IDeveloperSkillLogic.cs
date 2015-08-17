using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IDeveloperSkillLogic
    {
        IEnumerable<IDeveloperSkillBusinessModel> GetUserSkills(int userId);

        IEnumerable<IDeveloperSkillBusinessModel> GetPortfolioSkills(int portfolioId);
    }
}