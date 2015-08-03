using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Toci.Client.OauthProvider
{
    public class VazcoAuthenticationOptions : AuthenticationOptions
    {
        public string AppId;
        public string AppSecret;


        public VazcoAuthenticationOptions(string authenticationType, string appId, string appSecret) : base(authenticationType)
        {
            
            AppId = appId;
            AppSecret = appSecret;
            Caption = authenticationType;
            CallBack = ("http://localhost:13188/oauth/authentication");
            //CallBack = ("http://localhost:13188/Account/ExternalLoginCallback");
            AuthenticationMode = AuthenticationMode.Passive;
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            AuthorizationEndpoint = "http://oauth.stg.vazco.eu/oauth2/authorize";
            TokenEndpoint = "http://oauth.stg.vazco.eu/oauth2/token";
            UserInformationEndpoint = "http://oauth.stg.vazco.eu/oauth2/getIdentity";
        }

        public string UserInformationEndpoint { get; set; }


        public string TokenEndpoint { get; set; }

        public string AuthorizationEndpoint { get; set; }

        public TimeSpan BackchannelTimeout { get; set; }

        public string CallBack { get; set; }

        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

    }
}