using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;

namespace Phoenix.Front.Controllers
{
    public class WarriorTestController : Controller
    {
        private IDeveloperListLogic developerListLogic;
        private ITeamLeasingLogic teamLeasingLogic;

        public WarriorTestController(
            IDeveloperListLogic DeveloperListLogic,
            ITeamLeasingLogic TeamLeasingLogic
            )
        {
            developerListLogic = DeveloperListLogic;
            teamLeasingLogic = TeamLeasingLogic;
        }

        // GET: WarriorTest
        public ActionResult Index()
        {
            //teamLeasingLogic.GetTeams()

//            IEnumerable<IDeveloperTeamBusinessModel> teamsList = new List<IDeveloperTeamBusinessModel>
//            {
//                new DeveloperTeamBusinessModel() {  }  // mock
//                new DeveloperTeamBusinessModel() {  }
//                new DeveloperTeamBusinessModel() {  }
//                new DeveloperTeamBusinessModel() {  }
//                new DeveloperTeamBusinessModel() {  }
//                new DeveloperTeamBusinessModel() {  }
//            };

            //IDeveloperListLogic logic = new DeveloperListLogic();
            var devs = developerListLogic.GetAllDevelopers();
            return View();
        }
    }
}