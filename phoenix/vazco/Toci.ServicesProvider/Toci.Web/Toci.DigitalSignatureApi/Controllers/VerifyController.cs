using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class VerifyController : ApiController
    {
        
        [Route("/verify")]
        public bool Verify(string base64Data, string base64Signature, string base64Certyficate)
        {
            var verify = new Verify();
            return verify.VerifyFile(base64Data, base64Signature, base64Certyficate);
        }
    }
}
