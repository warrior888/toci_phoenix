using System;
using System.Threading.Tasks;
using IdServ.Configruation;
using Microsoft.Owin;
using Owin;
using Thinktecture.IdentityServer.Core.Configuration;

[assembly: OwinStartup(typeof(IdServ.Startup))]

namespace IdServ
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/core", 
                coreApp =>
            {
                coreApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Lol Identity Server",
                    SigningCertificate = Cert.Load(),
                    Factory = InMemoryFactory.Create(Users.Get(), Clients.Get(), Scopes.Get()),
                    RequireSsl = true
                });
            });
        }
    }
}
