using System.Collections.Generic;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Models;

namespace IdServ.Configruation
{
    public class Clients
    {//TODO tu beda nasze clienty, mozna brac z bazy,configu etc
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "implicitclient",
                    ClientName = "Example Implicit Client",
                    Enabled = true,
                    Flow = Flows.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>(),
                    PostLogoutRedirectUris = new List<string>(),
                    ScopeRestrictions = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email
                        

                    },
                    AccessTokenType = AccessTokenType.Jwt

                }
            };
        }  
    }
}