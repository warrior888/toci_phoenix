using System.Web.Mvc;

namespace Phoenix.Front.Areas.TeamLeasing
{
    public class TeamLeasingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TeamLeasing";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TeamLeasing_default",
                "TeamLeasing/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}