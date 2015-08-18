using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Phoenix.Bll.Interfaces.BusinessModels.DevelopersList
{
    public interface IPortfolioBusinessModel
    {
        int Id { get; set; }

        string ProjectName { get; set; }

        IEnumerable<ISkillBusinessModel> Skills { get; set; }

        //data od data do itd
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        int WeeksSpent { get; }
    }
}