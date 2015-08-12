using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Server.Models;

namespace Server
{
    public class ApplicationRoleStore:RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}