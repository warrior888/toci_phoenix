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