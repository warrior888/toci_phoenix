using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;
using Toci.DigitalSignatureApi.Logic;
using Toci.DigitalSignatureApi.Models;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class VerifyController : ApiController
    {
        private readonly DigitalSignatureApiUtils _digitalSignatureApiUtils = new DigitalSignatureApiUtils();

        [HttpPost]
        [Route("api/verify")]
        public string Verify([FromBody]VerifyModel model)
        {
            var isNullMessage = _digitalSignatureApiUtils.CheckForNull(model);
            if (isNullMessage != null)
            {
                return isNullMessage;
            }
            var verify = new Verify();
            try
            {
                model = _digitalSignatureApiUtils.DecodeVerifyModel(model);
                return verify.VerifyFile(model.data, model.signature, model.cert)? Constants.VerifyCorrectMsg : Constants.VerifyIncorrectMsg;
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