using System;
using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels
{
    public interface IPortfolioBusinessModel
    {
        string ProjectName { get; set; }

        IEnumerable<ISkillBusinessModel> Skills { get; set; }

        //data od data do itd
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        int WeeksSpent { get; }
    }
}