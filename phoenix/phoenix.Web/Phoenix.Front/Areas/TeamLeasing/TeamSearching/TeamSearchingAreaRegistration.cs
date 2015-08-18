using System.Web.Mvc;

namespace Phoenix.Front.Areas.TeamSearching
{
    public class TeamSearchingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TeamSearching";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TeamSearching_default",
                "TeamSearching/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}