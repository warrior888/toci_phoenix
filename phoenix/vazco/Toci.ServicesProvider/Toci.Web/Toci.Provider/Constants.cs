namespace Toci.Provider
{
    public class Constants
    {
        public const string DefaultAuthenticationType = "TociOAuth";
        internal const string AuthorizationEndpoint = "https://localhost:44300/OAuth/Authorize"; //"https://www.facebook.com/dialog/oauth"
        internal const string TokenEndpoint = "https://localhost:44300/OAuth/Token"; //"https://graph.facebook.com/oauth/access_token"
        internal const string UserInformationEndpoint = "https://graph.facebook.com/me";
    }
}