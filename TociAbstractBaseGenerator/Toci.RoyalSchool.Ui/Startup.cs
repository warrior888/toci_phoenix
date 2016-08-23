using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toci.RoyalSchool.Ui.Startup))]
namespace Toci.RoyalSchool.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
