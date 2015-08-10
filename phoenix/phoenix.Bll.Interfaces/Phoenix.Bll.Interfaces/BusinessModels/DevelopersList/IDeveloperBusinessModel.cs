using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface IDeveloperBusinessModel
    {
        string Nick { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        double Score { get; set; }

        DateTime ExperienceFrom { get; set; }

        IDeveloperAvailableBusinessModel DeveloperAvailable { get; set; }

        IEnumerable<ISkillBusinessModel> Skills { get; set; }

        IEnumerable<IPortfolioBusinessModel> Portfolio { get; set; }
    }
}