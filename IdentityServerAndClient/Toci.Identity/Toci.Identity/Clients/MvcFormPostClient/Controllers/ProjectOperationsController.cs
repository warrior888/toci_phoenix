using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFormPostClient.Models;

namespace MvcFormPostClient.Controllers
{
    public class ProjectOperationsController : Controller
    {
        // GET: ProjectOperations
        public ActionResult Create()
        {
            return View(new ClaimedProjectListModel());
        }
    }
}