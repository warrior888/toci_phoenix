using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toci.Bll.Nfs;
using Toci.Dal.Aoe.Interfaces;
using Toci.Front.Models;

namespace Toci.Front.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public void Create(ApplyForm model)
        {
            //todo save to db
            RegistrationLogicBase registrationBll = new RegistrationLogicBase(new Dal<ApplyForm>(new tociEntities()));

            registrationBll.Register(model);
            //RedirectToAction("Index");
        }

        [HttpGet]
        public void Email(string token)
        {

        }
    }
}
