using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing
{
    public interface ITeamLeasingBusinessModel
    {
        TeamLeasingOffer LeasingOffer { get; set; }

        IEnumerable<ISkillBusinessModel> SkillSet { get; set; }

        IDeveloperAvailableBusinessModel AvailableBusinessModel { get; set; }

        //DateTime RentFor { get; set; }  ???

        int CountOfTeam { get; set; }
    }
}