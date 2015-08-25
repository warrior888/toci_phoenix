using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Bll.Interfaces.BusinessModels.InteractiveCourses;
using Phoenix.Bll.Interfaces.Logic.InteractiveCourses;

namespace Phoenix.Front.Areas.InteractiveCourses.Controllers
{
    public class InteractiveCoursesController : Controller
    {
        private IInteractiveCoursesUserAuthorization _userAuthorization;
        private IInteractiveCoursesLogic _courseLogic;
        

        public InteractiveCoursesController(IInteractiveCoursesUserAuthorization userAuthorization,IInteractiveCoursesLogic courseLogic)    //parametrem jest typ interfejsowy w ktorym zawarte są wszystkie metody ktore maja sie wykonac
        {
            _userAuthorization = userAuthorization;
            _courseLogic = courseLogic;
        }

        // GET: InteractiveCourses/InteractiveCourses
        public ActionResult Index()
        {

            var isEntryAllowed = _userAuthorization.CheckUserAccountBalance(5);
            try
            {
                if (isEntryAllowed)
                {
                    //dalsza logika
                    
                }
            }
            catch (Exception)
            {
                
               
            }
            return View();
        }
    }
}