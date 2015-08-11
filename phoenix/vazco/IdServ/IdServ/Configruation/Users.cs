using System.Collections.Generic;
using System.Security.Claims;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace IdServ.Configruation
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {//TODO userzy pobierani z bazy
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "Scott Brady",
                    Password = "Password123!",
                    Subject = "1",
                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.GivenName,"Scott"),
                        new Claim(Constants.ClaimTypes.FamilyName,"Brady"),
                        new Claim(Constants.ClaimTypes.Email,"info@scottbrady91.com")
                    }
                }
            };
        } 
    }
}