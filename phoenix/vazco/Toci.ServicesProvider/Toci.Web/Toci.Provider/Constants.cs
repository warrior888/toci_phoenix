namespace Toci.Provider
{
    public class Constants
    {
        public const string DefaultAuthenticationType = "TociOAuth";
        internal const string AuthorizationEndpoint = "http://oauth.stg.vazco.eu/oauth2/"; // "https://localhost:44300/OAuth/Authorize"; //"https://www.facebook.com/dialog/oauth"
        internal const string TokenEndpoint = "https://oauth.stg.vazco.eu/oauth2/OAuth/Token"; //"https://graph.facebook.com/oauth/access_token"
        internal const string UserInformationEndpoint = "https://oauth.stg.vazco.eu/oauth2/Me";
    }
}