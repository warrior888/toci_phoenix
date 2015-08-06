using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Toci.Client.Models;

namespace Toci.Client.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ViewAllUsers()
        {
            return View(GetAllUsers());
        }

        public AdminModel GetAllUsers()
        {
            var context = new ApplicationDbContext();
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var adminModel = new AdminModel();
            var userList = context.Users.ToList();
            var adminModelList = adminModel.UserDataList.ToList();
            foreach (var user in userList)
            {
                var rolesForUser = userManager.GetRoles(user.Id);
                var userModel = new UserModel
                {
                    id = user.Id,
                    email = user.Email,
                    UserRoleList = rolesForUser
                };
                adminModelList.Add(userModel);
            }
            adminModel.UserDataList = adminModelList;
            return adminModel;
        }
      
    }
    
}