using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Client1.Controllers
{
    public class AccountController : Controller
    {
        private const string ClientUri = @"https://localhost:44304";
        private const string CallbackEndpoint = @"/account/signInCallback";
        private const string IdServBaseUri = @"https://localhost:44300/core";
        private const string AuthorizeUri = IdServBaseUri + @"/connect/authorize";

        public ActionResult SignIn()
        {
            var state = Guid.NewGuid().ToString("N");
            var nonce = Guid.NewGuid().ToString("N");

            var url = AuthorizeUri +
                "?client_id=implicitclient" +
                "&response_type=id_token" +
                "&scope=openid email profile" +
                "&redirect_uri=" + CallbackEndpoint +
                "&response_mode=form_post" +
                "&state=" + state +
                "&nonce=" + nonce;

            this.SetTempCookie(state, nonce);

            return this.Redirect(url);
        }

        private void SetTempCookie(string state, string nonce)
        {
            var tempId = new ClaimsIdentity("TempCookie");
            tempId.AddClaim(new Claim("state",state));
            tempId.AddClaim(new Claim("nonce",nonce));

            this.Request.GetOwinContext().Authentication.SignIn(tempId);
        }
        //TODO CDN
    }
}