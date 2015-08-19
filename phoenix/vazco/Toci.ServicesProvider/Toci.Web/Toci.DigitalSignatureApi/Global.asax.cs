using System.Web;
using System.Web.Http;

namespace Toci.DigitalSignatureApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
