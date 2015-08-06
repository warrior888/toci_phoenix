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
            return View();
        }
        /*
            tutaj domyślnie powinien być panel administratora - powinien pozwalać wyciągnąć wszystkich użytkowników
            i wyświetlić na przykład tych który nie mają żadnej roli, lub takich z danej roli, lub po prostu dane jednego konkretnego użytkownika po userName
            dodatkowo powinien pozwalać na dodanie nowych scopeów

            Realizacja zależy od tego co powie vazco.
        */
    }
    
}