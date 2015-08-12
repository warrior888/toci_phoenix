using System;
using IdentityManager.AspNetIdentity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Server.Models;

namespace Server
{
    public class ApplicationIdentityManagerService:AspNetIdentityManagerService<ApplicationUser,string,IdentityRole,string>
    {
        public ApplicationIdentityManagerService(ApplicationUserManager userMgr,ApplicationRoleManager roleMgr)
            :base(userMgr,roleMgr)
        {
        }
    }
}