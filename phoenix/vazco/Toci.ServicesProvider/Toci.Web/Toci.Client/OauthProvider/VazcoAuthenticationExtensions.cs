using System;
using Owin;


namespace Toci.Client.OauthProvider
{
    public static class VazcoAuthenticationExtensions
    {

        public static IAppBuilder UseVazcoAuthentication(this IAppBuilder app, VazcoAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use(typeof(VazcoAuthenticationMiddleware), app, options);
            return app;
        }


        public static IAppBuilder UseVazcoAuthentication(this IAppBuilder app, string appId, string appSecret)
        {
            return UseVazcoAuthentication(app, new VazcoAuthenticationOptions("Vazco", appId, appSecret));
        }

    }
}



