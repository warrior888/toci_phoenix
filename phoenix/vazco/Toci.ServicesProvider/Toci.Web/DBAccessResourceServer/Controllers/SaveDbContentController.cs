using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Models;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;

namespace DBAccessResourceServer.Controllers
{
    public class SaveDbContentController : Controller
    {
        // GET: SaveDbContent
        public ActionResult SaveContent(DbModel model)
        {
          
            

            return View(model);
        }
    }
}