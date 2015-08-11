using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace IdServ.Configruation
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email
            };
        }  
    }
}