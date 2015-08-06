using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Toci.Client.Models;

namespace Toci.Client.Logic
{
    public class UserRoleHandler
    {
        public async Task<bool> AddNewUserRole(DbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //IdentityResult roleResult; //<-jakby się okazało że IdentityResult przechowuje jakieś ważne/przydatne dalej dane

            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            return roleManager.RoleExists(roleName);
        }

        public async Task<bool> AddRoleToUser(DbContext context, string userId, string roleName)
        {

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = userManager.FindByIdAsync(userId);
            if (user != null && roleManager.RoleExists(roleName))
            {
                await userManager.AddToRoleAsync(userId, roleName);
                return userManager.IsInRole(userId, roleName);
            }
            return false;
        }

        
    }
}