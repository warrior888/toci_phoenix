using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Logic.TeamLeasing;
using Phoenix.Front.Areas.TeamLeasing.Models;

namespace Phoenix.Front.Areas.TeamLeasing.Controllers
{
    public class TeamSearchingController : Controller
    {
        private ITeamLeasingBusinessModel buiBusinessModel;
        private ITeamLeasingLogic leasingLogic;
        public IEnumerable<IDeveloperTeamBusinessModel> FindedTeam;
        // GET: TeamLeasing/TeamSearching
        TeamSearchingViewModel _model = new TeamSearchingViewModel();

        [HttpGet]
        public ActionResult Search(TeamSearchingViewModel model)
        {
            
            
            return View(model);
        }

        [HttpPost]
        public ActionResult _SearchResults(TeamLeasingBusinessModel model)
        {
            
            return View(model);
        }

        public ActionResult _TeamSearching(TeamSearchingViewModel model)
        {
           

            return View(model);
        }

        public ActionResult GetResults(TeamSearchingViewModel viewModel)
        {
            TeamLeasingBusinessModel model = new TeamLeasingBusinessModel();

            return View("_SearchResults", model);
        }
    }
}