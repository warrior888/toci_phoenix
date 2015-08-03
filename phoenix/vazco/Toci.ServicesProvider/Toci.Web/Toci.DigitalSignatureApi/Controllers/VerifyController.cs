using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            model = DecodeVerifyModel(model);
            var data1 = Convert.ToBase64String(Encoding.ASCII.GetBytes(model.data)); //test purposes only - writing only string not base64 as data
            return verify.VerifyFile(data1, model.signature, model.cert);
        }

        private VerifyModel DecodeVerifyModel(VerifyModel model)
        {
            model.signature = Convert.ToBase64String(HttpServerUtility.UrlTokenDecode(model.signature));
            return model;
        }
    }
}