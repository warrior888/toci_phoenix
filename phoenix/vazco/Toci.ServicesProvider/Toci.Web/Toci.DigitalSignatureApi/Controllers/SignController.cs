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
            try
            {
                return HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data, model.cert));
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

       [HttpPost]
        [Route("api/passwordsign")]
        public string PasswordSign([FromBody]SecuredSignModel model)
       {
            model = DecodeSignModel(model);
            var sign = new Sign();
           try
           {
               return HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data, sign.PfxFileToCertificate(model.cert, model.password)));
            }
           catch (Exception e)
           {

               return e.Message;
           }
            
            
        }

        private SecuredSignModel DecodeSignModel(SecuredSignModel model)
        {
            /*
            Nie wiem czemu nie może zrobić tego w ten sposób, prawdopodobnie base64string nie jest zgodny z tą metodą...
            Nie jest to piękne ale ' ' => '+' wystarcza
            */
            //model.cert = Convert.ToBase64String(HttpServerUtility.UrlTokenDecode(model.cert));
            model.cert = model.cert.Replace(' ', '+');
            return model;
        }
    }
}
