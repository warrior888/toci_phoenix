using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Toci.AuthorizationServer.Utilities;

namespace Toci.AuthorizationServer.Objects
{
    public class AuthorizationServerOptions
    {
        public AuthorizationServerOptions()
        {
            ServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AuthorizeEndpointPath = new PathString(Paths.AuthorizePath), //ścieżki
                    TokenEndpointPath = new PathString(Paths.TokenPath),
                    ApplicationCanDisplayErrors = true,
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    AllowInsecureHttp = false,

                    // Authorization server provider which controls the lifecycle of Authorization Server
                    Provider = new OAuthAuthorizationServerProvider
                    {
                       // OnValidateClientRedirectUri =  ;//TODO Metoda do porównania usera z zapisanym klientem
                        //                    OnValidateClientAuthentication = ;
                        //                    OnGrantResourceOwnerCredentials = ;
                        //                    OnGrantClientCredentials = ;
                    },

                    // Authorization code provider which creates and receives authorization code
                    AuthorizationCodeProvider = new AuthenticationTokenProvider
                    {
    //                    OnCreate = ;
    //                    OnReceive = ;
                    },

                    // Refresh token provider which creates and receives referesh token
                    RefreshTokenProvider = new AuthenticationTokenProvider
                    {
    //                    OnCreate = ;
    //                    OnReceive = ;
                    }
                };
            
        }

        protected OAuthAuthorizationServerOptions ServerOptions;
        public OAuthAuthorizationServerOptions ReturnServerOptions() {return ServerOptions;}
        
    }
}