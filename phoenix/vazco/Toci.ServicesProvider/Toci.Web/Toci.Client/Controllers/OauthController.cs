using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        public async Task<ViewResult> Authentication(string code)
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
            var responseToken = (VazcoTokenModel)jsonToken.ToObject(typeof (VazcoTokenModel));
            var identityClient = new HttpClient();
            identityClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseToken.access_token);
            HttpResponseMessage identity = await identityClient.GetAsync("http://oauth.stg.vazco.eu/oauth2/getIdentity");
            var readContent = identity.Content.ReadAsStringAsync();
            var jsonIdentity = (JObject) JsonConvert.DeserializeObject(readContent.Result);
            var responseIdentity = (VazcoIdentityModel)jsonIdentity.ToObject(typeof(VazcoIdentityModel));
            
            return View(responseToken);
            
        }


    }
}