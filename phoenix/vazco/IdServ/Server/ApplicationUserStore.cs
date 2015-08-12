using Microsoft.AspNet.Identity.EntityFramework;
using Server.Models;

namespace Server
{
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext ctx)
            :base(ctx)
        {
            
        }
    }
}