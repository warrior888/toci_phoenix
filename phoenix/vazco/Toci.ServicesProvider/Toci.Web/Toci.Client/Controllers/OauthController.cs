using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Helpers;
using Toci.Client.OauthProvider;

namespace Toci.Client.Controllers
{
    public class OauthController : Controller
    {
        // GET: Oauth
        [Route("/oauth/authentication")]
        public async Task<ViewResult> Authentication(string code)
        {
            var Options = new VazcoAuthenticationOptions("Vazco", "1", "2");
            string tokenRequest = "grant_type=authorization_code" +
                  "&code=" + Uri.EscapeDataString(code) +
                  "&client_id=" + Uri.EscapeDataString(Options.AppId) +
                  "&client_secret=" + Uri.EscapeDataString(Options.AppSecret) +
                  "&redirect_uri=" + Uri.EscapeDataString(Options.CallBack);//tutaj ten redirect uri może nie musi być taki sam, może on może pukać w inny kontroler
            StringContent tokenString = new StringContent(tokenRequest);
            tokenString.Headers.Add("Conent-Type", "application/x-www-form-urlencoded");
            HttpClient _httpClient = new HttpClient();
            HttpResponseMessage tokenResponse = await _httpClient.PostAsync(Options.TokenEndpoint, tokenString);
            //tokenResponse.EnsureSuccessStatusCode();
            string text = await tokenResponse.Content.ReadAsStringAsync();
            IFormCollection form = WebHelpers.ParseForm(text);
            string accessToken = form["access_token"];
            string refreshToken = form["refresh"];
            string expires = form["expires"];

            //_httpClient.GetAsync(Options.UserInformationEndpoint); //razem z accessTokenem który outrzymaliśmy od vazco możemy uderzyć z claimsami pod ten adres a w odpowiedzi dostaniemy dane użytkownika
            return View();
        }
    }
}