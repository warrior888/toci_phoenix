using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.TeamLeasing;

namespace Phoenix.Front.Areas.TeamLeasing.Controllers
{
    public class TeamSearchingController : Controller
    {
        private ITeamLeasingBusinessModel buiBusinessModel;
        private ITeamLeasingLogic leasingLogic;
        public IEnumerable<IDeveloperTeamBusinessModel> FindedTeam; 
        // GET: TeamLeasing/TeamSearching
        public ActionResult Index()
        {   
            

            return View();
        }
    }
}