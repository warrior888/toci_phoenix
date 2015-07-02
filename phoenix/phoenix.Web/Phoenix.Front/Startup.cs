using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Phoenix.Front.Startup))]
namespace Phoenix.Front
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
