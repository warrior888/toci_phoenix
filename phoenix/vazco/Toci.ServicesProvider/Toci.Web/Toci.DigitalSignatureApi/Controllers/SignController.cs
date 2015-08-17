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
    public class SignController : ApiController
    {
        [HttpPost]
        [Route("api/sign")]
        public string Sign([FromBody]SignModel model)
        {
            var sign = new Sign();
           // var data1 =  Convert.ToBase64String(Encoding.ASCII.GetBytes(model.data)); //testing purposes only
            return HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data, model.cert));
                //Convert.ToBase64String(sign.SignFile(data1, cert));
        }

        [HttpPost]
        [Route("api/sign")]
        public string Sign([FromBody]SecuredSignModel model)
        {
            var sign = new Sign();
            return
                HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data,
                    sign.PfxFileToCertificate(model.cert, model.password)));
            
        }
    }


}
