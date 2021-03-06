﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Toci.Client.Logic;
using Toci.Client.Models;

namespace Toci.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }


        //dodane po to aby podnieść usera do admina - domyślnie oczywiźcie nie będzie takiej metody
        //http://localhost:13188/home/signadminrole?user=nirvana007@onet.pl
        [HttpGet]
        public async Task<RedirectToRouteResult> SignAdminRole(string userName)
        {
            UserRoleHandler roleHandler = new UserRoleHandler();
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            await roleHandler.AddRoleToUser(context, user.Id, "admin");
            return RedirectToAction("Index", "Admin");
        }
    }
}