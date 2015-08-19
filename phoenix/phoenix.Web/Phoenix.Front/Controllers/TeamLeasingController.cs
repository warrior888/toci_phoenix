using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.TeamLeasing;
using Phoenix.Front.Models;

namespace Phoenix.Front.Controllers
{

    public class TeamLeasingViewModel
    {
        public ITeamLeasingLogic teamLeasingLogic { get; set; }
        public IEnumerable<IDeveloperTeamBusinessModel> Teams { get; set; } 
        public IDeveloperTeamBusinessModel oneTeam { get; set; }
    }

    public class TeamLeasingController : Controller
    {
        private ITeamLeasingLogic _teamLeasingLogic;
        
        public TeamLeasingController(ITeamLeasingLogic TeamLeasingLogic)
        {
            _teamLeasingLogic = TeamLeasingLogic;
        }

        public TeamLeasingController()
        {
            
        }

     // GET: TeamLeasing
        public ActionResult IndexMock()
        {
            TeamLeasingViewModel vm = new TeamLeasingViewModel();
          
           
        
            return View();
            
        }

        public ActionResult PostTesting(FormCollection data)
        {
            var nazwa = data["Nazwa"];

            return new EmptyResult();
        }



    }
}