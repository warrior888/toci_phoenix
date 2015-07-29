using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class SignController : ApiController
    {
        [HttpGet]
        [Route("/Sign")]
        public string Sign(string base64Data, string base64Certyficate)
        {
            var sign = new Sign();
            return Convert.ToBase64String(sign.SignFile(base64Data, base64Certyficate));
        }
    }
}
