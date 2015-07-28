using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Toci.AuthorizationClient.Models;
/// <summary>
/// generalnie zrobiliśmy łączenie z bazą danych z DbHandle, szyfrujemy i do niej wrzucamy, przy wyciąganiu deszyfrowaniu
/// na tym zatrzymaliśmy się jak kosa na kamieniu i nic konkretnego nie umiemy popchnąć, myślę że na tym etapie
/// to dalej sami nie przejdziemy, bo tu trzeba kogoś z wiedzą o budowie aplikacji klient-server a nie kogoś kto w zeszły piątek 
/// dowiadywał się co to MVC :) 
/// </summary>
namespace Toci.AuthorizationClient
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            //IOAuthAuthorizationServerProvider

            //FacebookAuthenticationMiddleware

            app.Use(typeof(FacebookAuthenticationMiddleware), app, new FacebookAuthenticationOptions()
            {
                TokenEndpoint = "/OAuth/Token",
                //Provider = 
                Caption = "a to co za kapszyn",
                //AuthenticationMode = 
                AuthenticationType = "TociOAuth",
                AppId = "1",
                AppSecret = "2",
                AuthorizationEndpoint = "https://localhost:44300/OAuth/Authorize",
                Description = new AuthenticationDescription() { Caption = "nasz kapszyn", AuthenticationType = "TociOAuth"}
                
            });

            //AuthenticationHandler
//            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
//            {
//                
//                AuthorizeEndpointPath = "/",
//                //TokenEndpointPath = 
//                //Provider = 
//            });

            //myślę że to spełni funkcjonalność klienta - tworzy Bearer token
//            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
//            {
//                Description = new AuthenticationDescription() { Caption = "TociOAuthAuthorizationServer", AuthenticationType = "TociOAuthAuthorizationServer" },
//                AuthenticationType = "TociOAuthAuthorizationServer",
//                AccessTokenProvider = new AuthenticationTokenProvider()
//                {
//                    OnCreate = create,
//                    OnReceive = receive,
//                    OnCreateAsync = CreateAsync,
//                    OnReceiveAsync = ReceiveAsync
//                },
//               
//                Provider = new OAuthBearerAuthenticationProvider()
//                {
//                    
//                    OnValidateIdentity = ValidateIdentity,
//                    OnApplyChallenge = ApplyChallenge,
//                    OnRequestToken = context =>
//                    {
//                        ///tutaj jest tworzone zapytanie do serwera autentykującego - na razie dodaje sam barer token, oraz na sucho clintId i  secret
//                       ///Czemu to ze sobą nie chce działać - my nie doszliśmy do tego. Ile ludzi tyle różnych implementacji, ale nikt nie pochwalił się nigdzie
//                       /// integracją serwera z entity frameworkiem, albo klienta który jest custumowy i ma swój serwer i jest bardziej rozwinięty niż aplikacja w cmd...
//                        if (context.Request.Path.Value.StartsWith("https://localhost:44300/OAuth/"))
//                        {
//                            string bearerToken = context.Request.Query.Get("bearer_token");
//                            if (bearerToken != null)
//                            {
//                                string[] authorization = new string[] { "bearer " + bearerToken, "clientId 1", "clientSecret 2" };
//                                context.Request.Headers.Add("Authorize", authorization);
//                            }
//                        }
//                        return Task.FromResult(context);
//                    } ,               
//                }
//               
//            });
            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");
            ///dla testów dodałem logowanie przez facebooka - można sobie prześledzić co robi externalLogin- on po wykonaniu zbiera dane które otrzymał z serwera
            /// i na ich podstawie już odwołuje się do DbContext i tworzy nowego użytkownika na ich podstawie...
            
            app.UseFacebookAuthentication(
               appId: "1469468426698430",
               appSecret: "8f508435a5992e539e2afac5bb8eba6f");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});

        }
        public static Action<AuthenticationTokenCreateContext> create = new Action<AuthenticationTokenCreateContext>(c =>
        {
            c.SetToken(c.SerializeTicket());
        });

        public static Action<AuthenticationTokenReceiveContext> receive = new Action<AuthenticationTokenReceiveContext>(c =>
        {
            c.DeserializeTicket(c.Token);
            c.OwinContext.Environment["Properties"] = c.Ticket.Properties;
        });
        public static async System.Threading.Tasks.Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            context.SetToken(context.SerializeTicket());
        }

        public static async System.Threading.Tasks.Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }

        public static Task ApplyChallenge(OAuthChallengeContext context)
        {
            context.Response.Redirect("/Account/Login");
            return Task.FromResult<object>(null);
        }

        //public static Task RequestToken(OAuthRequestTokenContext context)
        //{
        //    string token = context.Request.Cookies[0];
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        context.Token = token;
        //    }
        //    return Task.FromResult<object>(null);
        //}
        public static Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            return Task.FromResult<object>(null);
        }
    }
}