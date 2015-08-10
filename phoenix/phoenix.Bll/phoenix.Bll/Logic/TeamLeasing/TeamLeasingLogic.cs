using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Toci.Db.Interfaces;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class TeamLeasingLogic : ITeamLeasingLogic
    {
        public IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams)
        {
            throw new System.NotImplementedException();
        }

        public void RentTeam(IDeveloperTeamBusinessModel developerTeam)
        {
            throw new System.NotImplementedException();
        }
    }
}