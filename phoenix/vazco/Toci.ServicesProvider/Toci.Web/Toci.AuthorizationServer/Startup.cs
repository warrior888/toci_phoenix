using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toci.AuthorizationServer.Startup))]
namespace Toci.AuthorizationServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
