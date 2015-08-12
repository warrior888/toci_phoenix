using System.Collections.Generic;
using System.Linq;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Dal.GeneratedModels;
//using Phoenix.Dal.PatrykGeneratedModels;
using Toci.Db.Interfaces;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class TeamLeasingLogic : DbLogic, ITeamLeasingLogic
    {
        public IEnumerable<IDeveloperTeamBusinessModel> GetTeams(ITeamLeasingBusinessModel model, int countOfTeams)
        {
           // DbHandle.GetData(new skills_technologies { tech_name = model .SkillSet.First().SkillName});
            throw new System.NotImplementedException();
        }

        public void RentTeam(IDeveloperTeamBusinessModel developerTeam)
        {
            throw new System.NotImplementedException();
        }
    }
}