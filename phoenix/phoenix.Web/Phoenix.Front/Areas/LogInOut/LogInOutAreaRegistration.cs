using System.Web.Mvc;

namespace Phoenix.Front.Areas.LogInOut
{
    public class LogInOutAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LogInOut";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LogInOut_default",
                "LogInOut/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}