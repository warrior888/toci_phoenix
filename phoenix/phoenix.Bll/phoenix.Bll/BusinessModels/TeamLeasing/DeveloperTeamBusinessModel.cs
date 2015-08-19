using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.BusinessModels.TeamLeasing
{
    public class DeveloperTeamBusinessModel : IDeveloperTeamBusinessModel
    {
        public int id { get; set; }
        public IDeveloperBusinessModel TeamLeader { get; set; }
        public IEnumerable<IDeveloperBusinessModel> AdditionalTeamMembers { get; set; }
        public IEnumerable<IPortfolioBusinessModel> TeamPortfolio { get; set; }
    }
}