using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoenix.Front.Areas.Registration.Models;

namespace Phoenix.Front.Areas.Registration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration/Registration

        // GET: Registration/Registration
        [HttpGet]
        public ActionResult RegistrationForm()
        {
            // Users user = new Users();


            return View();
        }

        [HttpPost]
        public ActionResult RegistrationForm(RegistrationModel model)
        {


            // Users user = new Users();
            return (ModelState.IsValid) ?
           View("CorrectRegistration") :
             View();

        }
    }
}