using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toci.AuthorizationClient.Startup))]
namespace Toci.AuthorizationClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
