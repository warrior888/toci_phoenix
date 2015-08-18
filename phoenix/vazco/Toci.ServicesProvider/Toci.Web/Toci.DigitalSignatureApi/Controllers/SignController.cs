using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Microsoft.SqlServer.Server;
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
            var isNullMessage = CheckForNull(model);
            if (isNullMessage != null)
            {
                return isNullMessage;
            }
            try
            {
                return HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data, model.cert));
            }
            catch (CryptographicException)
            {

                return "Invalid certificate file";
            }
            catch (FormatException)
            {
                return "Invalid base64String";
            }
        }

        [HttpPost]
        [Route("api/passwordsign")]
        public string PasswordSign([FromBody]SecuredSignModel model)
        {
            var isNullMessage = CheckForNull(model);
            if (isNullMessage != null)
            {
                return isNullMessage;
            }
            var sign = new Sign();
            try
            {
                model = DecodeSignModel(model);
                return
                    HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data,
                        sign.PfxFileToCertificate(model.cert, model.password)));
            }
            catch (CryptographicException)
            {

                return "Invalid password or certificate file";
            }
            catch (FormatException)
            {
                return "Invalid base64String";
            }
            

        }

        private SecuredSignModel DecodeSignModel(SecuredSignModel model)
        {
            model.cert = model.cert.Replace(' ', '+');
            return model;
        }

        private string CheckForNull(object model)
        {
            List<string> message = new List<string>();
            var properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model, null) == null)
                    message.Add(property.Name);
            }

            return message.Count > 0 ? string.Join(" & ", message.ToArray()) + " fields cannot be empty" : null;
        }
    }
}
