using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;

namespace Phoenix.Bll.Interfaces.Logic.TeamLeasing
{
    public interface ITeamLeasingLogic : IDbLogic
    {
        IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams);

        void RentTeam(IDeveloperTeamBusinessModel developerTeam);
    }
}