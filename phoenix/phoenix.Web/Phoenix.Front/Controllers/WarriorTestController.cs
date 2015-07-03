using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.DevelopersList;
using Phoenix.Bll.Interfaces.DevelopersList;

namespace Phoenix.Front.Controllers
{
    public class WarriorTestController : Controller
    {
        private IDeveloperListLogic developerListLogic;

        public WarriorTestController(
            IDeveloperListLogic DeveloperListLogic
            )
        {
            developerListLogic = DeveloperListLogic;
        }

        // GET: WarriorTest
        public ActionResult Index()
        {
            //IDeveloperListLogic logic = new DeveloperListLogic();
            var devs = developerListLogic.GetAllDevelopers();
            return View();
        }
    }
}