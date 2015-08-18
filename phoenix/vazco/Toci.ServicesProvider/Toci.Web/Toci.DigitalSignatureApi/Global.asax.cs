using System.Net.Http.Formatting;
using System.Web.Http;

namespace Toci.DigitalSignatureApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
