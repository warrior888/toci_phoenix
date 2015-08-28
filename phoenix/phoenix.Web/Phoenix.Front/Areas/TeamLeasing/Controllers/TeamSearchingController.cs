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

      

        //TODO: DI
        private ITeamLeasingBusinessModel _buiBusinessModel;
        private ITeamLeasingLogic _leasingLogic;
        public IEnumerable<IDeveloperTeamBusinessModel> FoundTeam;
        TeamSearchingViewModel _model = new TeamSearchingViewModel();
        // GET: TeamLeasing/TeamSearching

     
        public TeamSearchingController( ITeamLeasingLogic leasingLogic)
        {
            _buiBusinessModel = new TeamLeasingBusinessModel();
            _leasingLogic = leasingLogic;
        }

        [HttpGet]
        public ActionResult Search()
        {
           
            return View(_model);
        }

        [HttpPost] //TODO: Ajax
        public ActionResult _SearchResults(TeamSearchingViewModel model)
        {
            return PartialView(model);
        }

        public ActionResult _TeamSearching(TeamSearchingViewModel model)
        {
           return View(model);
        }

        [HttpPost] //TODO: AutoMapper
        public ActionResult GetResults(TeamSearchingViewModel viewModel)
        {
            TeamLeasingBusinessModel model = new TeamLeasingBusinessModel();
            

        

            viewModel.test = "GetResults";

            return _SearchResults(viewModel);
        }

        protected DateTime StringDateTimeParserPl(string date)
        {
            if (date == null) return default(DateTime);

            var splitDate = date.Split(new[] { '.' }, 3);
            int day = int.Parse(splitDate[0]);
            int month = int.Parse(splitDate[1]);
            int year = int.Parse(splitDate[2]);

            return new DateTime(year, month, day);
        }
    }
}