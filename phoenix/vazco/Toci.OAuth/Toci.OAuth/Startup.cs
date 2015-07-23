using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toci.OAuth.Startup))]
namespace Toci.OAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
