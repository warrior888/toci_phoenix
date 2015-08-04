using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Toci.Client.Models;
using Toci.Client.OauthProvider;

namespace Toci.Client.Controllers
{
    public class OauthController : Controller
    {
        public ActionResult Index()
        {
            string VazcoAuthUri =
                String.Format(
                    "{0}?response_type={1}&client_id={2}&redirect_uri={3}", "http://oauth.stg.vazco.eu/oauth2/authorize",
                    "code", "testoauth", "http://localhost:13188/oauth/authentication"); 



            return Redirect(VazcoAuthUri);
        }
        // GET: Oauth
        //[HttpPost]
        [Route("/oauth/authentication")]
        public async Task<RedirectToRouteResult> Authentication(string code)
        {
            var requestClient = new HttpClient();
            var Params = new Dictionary<string,string>()
                {
                    {"grant_type", "authorization_code" },
                    {"code", code },
                    {"client_id", "testoauth" },
                    {"client_secret", "testoauth" },
                    {"redirect_uri", "http://localhost:13188/oauth/authentication" }
                };
            var content = new FormUrlEncodedContent(Params);
            var response = await requestClient.PostAsync("http://oauth.stg.vazco.eu/oauth2/token", content);

            var responseString = await response.Content.ReadAsStringAsync();


            var jsonToken = (JObject)JsonConvert.DeserializeObject(responseString);
            var token = (VazcoTokenModel)jsonToken.ToObject(typeof (VazcoTokenModel));
            var identityClient = new HttpClient();
            identityClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);
            HttpResponseMessage identityResponseMessage = await identityClient.GetAsync("http://oauth.stg.vazco.eu/oauth2/getIdentity");
            var readContent = await identityResponseMessage.Content.ReadAsStringAsync();
            var jsonIdentity = (JObject) JsonConvert.DeserializeObject(readContent);
            var identity = (VazcoIdentityModel)jsonIdentity.ToObject(typeof(VazcoIdentityModel));
            //^^ na tym etapie mamy informacje o użytkowniku 
            //Skaczemy albo do strony logowania albo do rejestracji nowego konta
            if (await IsRegistred(identity.id))
            {
                return RedirectToAction("Login", "Account", new LoginViewModel() { Email =identity.email });
            }
            var responseModel = ConvertToResponseModel(identity, token);
            TempData["responseModel"] = responseModel;
            return RedirectToAction("RegisterForm");

        }


        public VazcoResponseModel ConvertToResponseModel(VazcoIdentityModel identity, VazcoTokenModel token)
        {
            return new VazcoResponseModel() {id = identity.id, email = identity.email, access_token = token.access_token, token_type = token.token_type, expires_in = token.expires_in};
        }
        [HttpGet]
        public ViewResult RegisterForm()
        {
            var model = TempData["responseModel"];
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(string id, string email, string password)
        {

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            /*var result = await userManager.FindByIdAsync(id);
            if (result != null)
            {
                return RedirectToAction("Login", "Account", new LoginViewModel() {Email = email});
            }*/
            ApplicationUser user = new ApplicationUser() { Id = id, UserName = email, Email = email }; //do uzupełnienia jeśli dojdą nowe claimsy
            //var signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            var makeUser = await userManager.CreateAsync(user, password);
            if (makeUser.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                await SignIn(user.UserName, password);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ExternalLoginFailure", "Account", makeUser.Errors.First());
        }

        //
        private async Task<bool> SignIn(string userName, string password)
        {
            var signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            try
            {
                await signInManager.PasswordSignInAsync(userName, password, false, false);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> IsRegistred(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = await userManager.FindByIdAsync(id);
            return result != null;
        }

    }
}