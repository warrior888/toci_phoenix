using System.Web;
using System.Web.Optimization;

namespace Phoenix.Front
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery.easing.js",
                        "~/Scripts/jquery.sticky.js",
                        "~/Scripts/jquery.flexslider-min.js",
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/jquery.bxslider.js",
                        "~/Scripts/imagesloaded.min.js.js",
                        "~/Scripts/jquery.isotope.min.js",
                        "~/Scripts/jquery-countTo.js",
                        "~/Scripts/jquery.easypiechart.min.js",
                        "~/Scripts/jquery-waypoints.js",
                        "~/Scripts/parallax.js",
                        "~/Scripts/smoothscroll.js",                         
                        "~/Scripts/gmap3.min.js",
                        "~/Scripts/jquery.tweet.min.js",
                        "~/Scripts/main.js",
                        "~/Scripts/GoogleMaps.js",
                        "~/Scripts/DocumentReady.js",
                         "~/Scripts/scrolling-nav.js",
                         "~/Scripts/jquery.easing.min.js"
                        
                

                        ));

           /* bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));   */

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/style.css",
                      "~/Content/animate.css",
                      "~/Content/color/color1.css"  
                      ));
        }
    }
}
