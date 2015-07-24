using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Models;
using EncodingLib;

namespace DBAccessResourceServer.Controllers
{
    public class ReadDbContentController : Controller
    {
        // GET: ReadDbContent
        public ActionResult LoadContent(DbModel model)
        {
            //TODO db request for model
            model.data = "text text text text text ";
            model.nick = "Gerwazy";
            model.addingTime = new DateTime(2013,10,1,15,15,15);
            //end of ToDelete

            //model.data = Crypting.DecryptStringAES(model.data, sharedSecret.secret);

            return View(model);
        }
    }
}