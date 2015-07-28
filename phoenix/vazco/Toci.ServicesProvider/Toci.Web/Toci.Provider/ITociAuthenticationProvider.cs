// Decompiled with JetBrains decompiler
// Type: Microsoft.Owin.Security.Facebook.IFacebookAuthenticationProvider
// Assembly: Microsoft.Owin.Security.Facebook, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6EF4399B-2BF0-4696-962B-7896F8D7BE13
// Assembly location: C:\Users\Adam\Documents\toci_phoenix\phoenix\vazco\Toci.ServicesProvider\Toci.Web\packages\Microsoft.Owin.Security.Facebook.3.0.1\lib\net45\Microsoft.Owin.Security.Facebook.dll

using System.Threading.Tasks;


namespace Toci.Provider
{
    /// <summary>
    /// Specifies callback methods which the <see cref="T:Microsoft.Owin.Security.Facebook.FacebookAuthenticationMiddleware"/> invokes to enable developer control over the authentication process. /&gt;
    /// 
    /// </summary>
    public interface ITociAuthenticationProvider
    {
        /// <summary>
        /// Invoked whenever Facebook succesfully authenticates a user
        /// 
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="T:System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> representing the completed operation.
        /// </returns>
        Task Authenticated(TociAuthenticatedContext context);

        /// <summary>
        /// Invoked prior to the <see cref="T:System.Security.Claims.ClaimsIdentity"/> being saved in a local cookie and the browser being redirected to the originally requested URL.
        /// 
        /// </summary>
        /// <param name="context"/>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> representing the completed operation.
        /// </returns>
        Task ReturnEndpoint(TociReturnEndpointContext context);

        /// <summary>
        /// Called when a Challenge causes a redirect to authorize endpoint in the Facebook middleware
        /// 
        /// </summary>
        /// <param name="context">Contains redirect URI and <see cref="T:Microsoft.Owin.Security.AuthenticationProperties"/> of the challenge </param>
        void ApplyRedirect(TociApplyRedirectContext context);
    }
}