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
using Toci.Client.Logic.OauthConnectionLogic;

namespace Toci.Client.Controllers
{
    public class OauthController : Controller
    {
        public OauthConnectionUtils Utils = new OauthConnectionUtils();
        public ActionResult Index()
        {
            string VazcoAuthUri =
                string.Format(
                    "{0}?response_type={1}&client_id={2}&redirect_uri={3}", 
                    Constants.VazcoAuthorizeUri, Constants.AccessCode, Constants.AppId, Constants.LocalAuthenticationUri); 
            return Redirect(VazcoAuthUri);
        }

        [Route("/oauth/authentication")]
        public async Task<RedirectToRouteResult> Authentication(string code)
        {
            var responseModel = await Utils.GetResultOfConnectionToVazco(code);
            //Skaczemy albo do strony logowania albo do rejestracji nowego konta
            if (await Utils.IsRegistred(responseModel.id, System.Web.HttpContext.Current))
            {
                return RedirectToAction("Login", "Account", new LoginViewModel() { Email = responseModel.email });
            }
            TempData["responseModel"] = responseModel; //TODO czy da się to wypieprzyć?
            return RedirectToAction("RegisterForm");
        }

        public ViewResult RegisterForm()
        {
            var model = TempData["responseModel"];
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(string id, string email, string password)
        {

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            ApplicationUser user = new ApplicationUser() { Id = id, UserName = email, Email = email }; //do uzupełnienia jeśli dojdą nowe claimsy

            var makeUser = await userManager.CreateAsync(user, password);
            if (makeUser.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                await Utils.SignIn(user.UserName, password, System.Web.HttpContext.Current);
                //RETURN x.succeeded? jedna metoda : druga metoda
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ExternalLoginFailure", "Account", makeUser.Errors.First());
        }

    }
}