using System.Web.Mvc;

namespace Phoenix.Front.Areas.InteractiveCourses
{
    public class InteractiveCoursesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InteractiveCourses";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InteractiveCourses_default",
                "InteractiveCourses/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}