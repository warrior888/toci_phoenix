﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBAccessResourceServer.Controllers
{
    public class DbHubController : Controller
    {
        // GET: DbHub
        public ActionResult Index()
        {
            return View();
        }
    }
}