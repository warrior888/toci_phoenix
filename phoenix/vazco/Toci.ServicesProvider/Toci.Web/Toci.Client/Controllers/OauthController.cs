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
            var client = new HttpClient();

            var Params = new Dictionary<string,string>()
                {
                    {"grant_type", "authorization_code" },
                    {"code", code },
                    {"client_id", "testoauth" },
                    {"client_secret", "testoauth" },
                    {"redirect_uri", "http://localhost:13188/oauth/authentication" }
                };
            var content = new FormUrlEncodedContent(Params);
            var response = await client.PostAsync("http://oauth.stg.vazco.eu/oauth2/token", content);

            var responseString = await response.Content.ReadAsStringAsync();
            VazcoTokenModel responseToken = new VazcoTokenModel();

            var jsonToken = (JObject)JsonConvert.DeserializeObject(responseString);
            responseToken = (VazcoTokenModel)jsonToken.ToObject(typeof (VazcoTokenModel));

            return View(responseToken);

        }


    }
}