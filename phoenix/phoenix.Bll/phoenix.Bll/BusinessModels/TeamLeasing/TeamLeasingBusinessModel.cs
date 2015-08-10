using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.BusinessModels.TeamLeasing
{
    public class TeamLeasingBusinessModel : ITeamLeasingBusinessModel
    {
        public TeamLeasingOffer LeasingOffer { get; set; }

        public IEnumerable<ISkillBusinessModel> SkillBusinessModel { get; set; }

        public IDeveloperAvailableBusinessModel AvailableBusinessModel { get; set; }

        public int CountOfTeam { get; set; }
    }
}