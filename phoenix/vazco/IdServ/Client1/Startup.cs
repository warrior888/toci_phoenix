
using Microsoft.Owin.Security;
using Owin;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Web.Configuration;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode;

[assembly: OwinStartup(typeof(Client1.Startup))]

namespace Client1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "TempCookie",
                AuthenticationMode = AuthenticationMode.Passive
            });
        }
    }
}
