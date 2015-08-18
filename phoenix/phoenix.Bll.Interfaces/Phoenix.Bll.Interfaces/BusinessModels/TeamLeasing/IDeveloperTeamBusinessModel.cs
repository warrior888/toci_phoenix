using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing
{
    public interface IDeveloperTeamBusinessModel
    {
        int id { get; set; }

        IDeveloperBusinessModel TeamLeader { get; set; }

        IEnumerable<IDeveloperBusinessModel> AdditionalTeamMembers { get; set; }

        IEnumerable<IPortfolioBusinessModel> TeamPortfolio { get; set; }
    }
}