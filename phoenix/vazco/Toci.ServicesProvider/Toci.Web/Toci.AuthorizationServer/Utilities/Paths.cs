namespace Toci.AuthorizationServer.Utilities
{
    public static class Paths
    {
        public const string AccountRegisterPath = "http://localhost:6700/Account/Register";
        public const string DbAccessResourceServer = "http://localhost:11130/";

        public const string AuthorizePath = "/OAuth/Authorize";
        public const string TokenPath = "/OAuth/Token";
        public const string LoginPath = "/Account/Login";
        public const string LogoutPath = "/Account/Logout";
    }
}