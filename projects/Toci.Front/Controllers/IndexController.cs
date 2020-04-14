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
        protected RegistrationLogicBase registrationBll = new RegistrationLogicBase(new Dal<ApplyForm>(new tociEntities()));
        protected ContactLogicBase contactBll = new ContactLogicBase();
        protected ApplyLogicBase applyBll = new ApplyLogicBase();
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public void Create(ApplyForm model)
        {
            //todo save to db


            registrationBll.Register(model);
            //RedirectToAction("Index");
        }

        [HttpGet]
        public void Email(string token)
        {
            registrationBll.EmailConfirm(token);
        }

        [HttpPost]
        public JsonResult Contact(ContactForm form)
        {
            ContactForm result = contactBll.SaveContact(form);

            if (result.Id > 0)
            {
                return new JsonResult() { Data = new { result = true, message = "Zapisano !" } };
            }

            return new JsonResult() { Data = new { result = true, message = "Nie zapisano !" } };

        }
        [HttpPost]
        public JsonResult Apply(ApplyForm form)
        {
           // ApplyForm result = applyBll.SaveApply(form);
            ApplyForm result = registrationBll.Register(form);

            if (result.Id > 0)
            {
                return new JsonResult() { Data = new { result = true, message = "Zapisano !" } };
            }

            return new JsonResult() { Data = new { result = true, message = "Nie zapisano !" } };

        }

    }
}
