using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Infrastructure;
using Owin;


namespace Toci.Client.OauthProvider
{
    public class VazcoAuthenticationMiddleware : AuthenticationMiddleware<VazcoAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public VazcoAuthenticationMiddleware(OwinMiddleware next, IAppBuilder app, VazcoAuthenticationOptions options) : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(Options.AppId))
            {
                throw new ArgumentException("AppID cannot be empty!");
            }
            if (string.IsNullOrWhiteSpace(Options.AppSecret))
            {
                throw new ArgumentException("AppSecret cannot be empty!");
            }

            _httpClient = new HttpClient(new HttpClientHandler());
            _httpClient.Timeout = Options.BackchannelTimeout;
            _httpClient.MaxResponseContentBufferSize = 1024 * 1024 * 10;
        }

        protected override AuthenticationHandler<VazcoAuthenticationOptions> CreateHandler()
        {
            return new VazcoAuthenticationHandler(_httpClient, _logger);
        }
    }
}