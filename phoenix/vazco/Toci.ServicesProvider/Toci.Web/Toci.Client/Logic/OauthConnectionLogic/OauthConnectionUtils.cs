using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Toci.Client.Models;

namespace Toci.Client.Logic.OauthConnectionLogic
{
    public class OauthConnectionUtils
    {
        public async Task<VazcoResponseModel> GetResultOfConnectionToVazco(string code)
        {
            var token = await GetOauthToken(code);
            var identity = await GetUserIdentity(token);
            var responseModel = ConvertToResponseModel(identity, token);
            //^^ na tym etapie mamy informacje o użytkowniku 
            return responseModel;
        }

        public async Task<VazcoTokenModel> GetOauthToken(string code)
        {
            var requestClient = new HttpClient();
            var Params = new Dictionary<string, string>()
            {
                {Constants.GrantType, Constants.AuthorizationCode},
                {Constants.AccessCode, code},
                {Constants.ClientId, Constants.AppId},
                {Constants.ClientSecret, Constants.AppSecret},
                {Constants.RedirectUri, Constants.LocalAuthenticationUri}
            };
            var content = new FormUrlEncodedContent(Params);
            var response = await requestClient.PostAsync(Constants.VazcoTokenUri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var jsonToken = (JObject)JsonConvert.DeserializeObject(responseString);
            var token = (VazcoTokenModel)jsonToken.ToObject(typeof(VazcoTokenModel));
            return token;
        }

        public async Task<VazcoIdentityModel> GetUserIdentity(VazcoTokenModel token)
        {
            var identityClient = new HttpClient();
            identityClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.access_token);
            HttpResponseMessage identityResponseMessage =
            await identityClient.GetAsync(Constants.VazcoGetIdentityUri);
            var readContent = await identityResponseMessage.Content.ReadAsStringAsync();
            var jsonIdentity = (JObject)JsonConvert.DeserializeObject(readContent);
            var identity = (VazcoIdentityModel)jsonIdentity.ToObject(typeof(VazcoIdentityModel));
            return identity;
        }


        public VazcoResponseModel ConvertToResponseModel(VazcoIdentityModel identity, VazcoTokenModel token)
        {
            return new VazcoResponseModel() { id = identity.id, email = identity.email, access_token = token.access_token, token_type = token.token_type, expires_in = token.expires_in };
        }

        public async Task<bool> IsRegistred(string id, HttpContext context)
        {
            var userManager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = await userManager.FindByIdAsync(id);
            return result != null;
        }
        public async Task<bool> SignIn(string userName, string password, HttpContext context)
        {
            var signInManager = context.GetOwinContext().Get<ApplicationSignInManager>();
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
    }
}