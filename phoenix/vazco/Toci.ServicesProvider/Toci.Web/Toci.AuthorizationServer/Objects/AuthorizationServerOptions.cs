using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
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
                    AllowInsecureHttp = true,

                    // Authorization server provider which controls the lifecycle of Authorization Server
                    Provider = new OAuthAuthorizationServerProvider
                    {
                        OnValidateClientRedirectUri = ValidateClientRedirectUri,//TODO Metoda do porównania usera z zapisanym klientem
                        OnValidateClientAuthentication = ValidateClientAuthentication,
                        OnGrantResourceOwnerCredentials = GrantResourceOwnerCredentials,
                        OnGrantClientCredentials = GrantClientCredetails
                    },

                    // Authorization code provider which creates and receives authorization code
                    AuthorizationCodeProvider = new AuthenticationTokenProvider
                    {
                          OnCreate = CreateAuthenticationCode,
                          OnReceive = ReceiveAuthenticationCode
                    },

                    // Refresh token provider which creates and receives referesh token
                    RefreshTokenProvider = new AuthenticationTokenProvider
                    {
                          OnCreate = CreateRefreshToken,
                          OnReceive = ReceiveRefreshToken
                    }
                };
            
        }

        protected OAuthAuthorizationServerOptions ServerOptions;
        public OAuthAuthorizationServerOptions ReturnServerOptions() {return ServerOptions;}
        public Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == Client.Id)
            {
                context.Validated(Client.RedirectUrl);
            }
        
            return Task.FromResult(0);
        }

        public Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                if (clientId == Client.Id && clientSecret == Client.Secret)
                {
                    context.Validated();
                }
            }
            return Task.FromResult(0);
        }

        public Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.UserName, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }

        public Task GrantClientCredetails(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }

        public readonly ConcurrentDictionary<string, string> _authenticationCodes =
            new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        public void CreateAuthenticationCode(AuthenticationTokenCreateContext context)
        {
            context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
            _authenticationCodes[context.Token] = context.SerializeTicket();
        }

        public void ReceiveAuthenticationCode(AuthenticationTokenReceiveContext context)
        {
            string value;
            if (_authenticationCodes.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }

        public void CreateRefreshToken(AuthenticationTokenCreateContext context)
        {
            context.SetToken(context.SerializeTicket());
        }

        public void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}