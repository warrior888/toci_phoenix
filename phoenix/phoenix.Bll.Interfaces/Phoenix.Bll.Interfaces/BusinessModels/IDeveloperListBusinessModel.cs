using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels
{
    public interface IDeveloperListBusinessModel
    {
        string Nick { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        double Score { get; set; }

        IEnumerable<ISkillBusinessModel> Skills { get; set; }

        IEnumerable<IPortfolioBusinessModel> Portfolio { get; set; }
    }
}