using Microsoft.Owin;
using IdentityManager.Configuration;
using IdentityManager;
using IdentityManager.AspNetIdentity;
using Owin;
using Server.Models;

[assembly: OwinStartupAttribute(typeof(Server.Startup))]
namespace Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.Map("/idm",
                idm =>
                {
                    var factory = new IdentityManagerServiceFactory();
                    factory.IdentityManagerService = new Registration<IIdentityManagerService, ApplicationIdentityManagerService>();
                    factory.Register(new Registration<ApplicationUserManager>());
                    factory.Register(new Registration<ApplicationUserStore>());
                    factory.Register(new Registration<ApplicationRoleManager>());
                    factory.Register(new Registration<ApplicationRoleStore>());
                    //Possibility to extednd DbContext and connect own db.
                    factory.Register(new Registration<ApplicationDbContext>());

                    idm.UseIdentityManager(new IdentityManagerOptions
                    {
                        Factory = factory 
                    });
                });
        }
    }
}
