using System;
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

        
        public RedirectToRouteResult RemoveRole(string roleName, string userId)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            userManager.RemoveFromRole(userId, roleName);
            return RedirectToAction("ViewAllUsers");
        }


        [HttpPost]
        public async Task<RedirectToRouteResult> AddRole(string roleName, string userId)
        {
            UserRoleHandler roleHandler = new UserRoleHandler();
            var context = new ApplicationDbContext();
            await roleHandler.AddNewUserRole(context, roleName);
            await roleHandler.AddRoleToUser(context, userId, roleName);

            return RedirectToAction("ViewAllUsers");
        }
      
    }
    
}