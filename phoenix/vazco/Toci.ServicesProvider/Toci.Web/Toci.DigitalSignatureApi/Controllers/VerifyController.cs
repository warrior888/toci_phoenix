using System;
using System.Web;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;
using Toci.DigitalSignatureApi.Models;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class VerifyController : ApiController
    {
        [HttpPost]
        [Route("api/verify")]
        public bool Verify([FromBody]VerifyModel model)
        {
            var verify = new Verify();
            try
            {
                model = DecodeVerifyModel(model);
                //var data1 = Convert.ToBase64String(Encoding.ASCII.GetBytes(model.data)); //test purposes only - writing only string not base64 as data
                return verify.VerifyFile(model.data, model.signature, model.cert);
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        private VerifyModel DecodeVerifyModel(VerifyModel model)
        {
            model.cert = model.cert.Replace(' ', '+');
            model.signature = Convert.ToBase64String(HttpServerUtility.UrlTokenDecode(model.signature));
            return model;
        }
    }
}