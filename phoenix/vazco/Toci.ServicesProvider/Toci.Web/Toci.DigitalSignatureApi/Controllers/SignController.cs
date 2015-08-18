using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;
using Toci.DigitalSignatureApi.Logic;
using Toci.DigitalSignatureApi.Models;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class SignController : ApiController
    {
        private readonly DigitalSignatureApiUtils _digitalSignatureApiUtils = new DigitalSignatureApiUtils();

        [HttpPost]
        [Route("api/unsecuredsign")]
        public string UnsecuredSign([FromBody]SignModel model)
        {
            var sign = new Sign();
            var isNullMessage = _digitalSignatureApiUtils.CheckForNull(model);
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
                return Constants.InvalidCertificateExMsg;
            }
            catch (FormatException)
            {
                return Constants.InvalidBase64ExMsg;
            }
        }

        [HttpPost]
        [Route("api/sign")]
        public string Sign([FromBody]SecuredSignModel model)
        {
            var isNullMessage = _digitalSignatureApiUtils.CheckForNull(model);
            if (isNullMessage != null)
            {
                return isNullMessage;
            }
            var sign = new Sign();
            try
            {
                model = _digitalSignatureApiUtils.DecodeSignModel(model);
                return
                    HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data,
                        sign.PfxFileToCertificate(model.cert, model.password)));
            }
            catch (CryptographicException)
            {

                return Constants.InvalidCertificateExMsg;
            }
            catch (FormatException)
            {
                return Constants.InvalidBase64ExMsg;
            }


        }
    }
}
