using System.Web.Mvc;

namespace Phoenix.Front.Areas.TeamReservation
{
    public class TeamReservationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TeamReservation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TeamReservation_default",
                "TeamReservation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}