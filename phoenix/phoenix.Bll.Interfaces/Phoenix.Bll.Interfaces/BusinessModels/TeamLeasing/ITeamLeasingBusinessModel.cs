using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing
{
    public interface ITeamLeasingBusinessModel
    {
        int Id { get; set; }

        TeamLeasingOffer LeasingOffer { get; set; }

        IEnumerable<IDeveloperSkillBusinessModel> SkillSet { get; set; }

        IDeveloperAvailableBusinessModel AvailableBusinessModel { get; set; }

        //DateTime RentFor { get; set; }  ???

        int CountOfTeam { get; set; }
    }
}