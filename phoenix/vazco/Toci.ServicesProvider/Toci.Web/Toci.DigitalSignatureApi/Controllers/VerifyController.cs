using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;
using Toci.DigitalSignatureApi.Abstraction;
using Toci.DigitalSignatureApi.Logic;
using Toci.DigitalSignatureApi.Models;
using Toci.Utilities.Api;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class VerifyController : TmpDsTociApiController
    {

        [HttpPost]
        [Route("api/verify")]
        public Dictionary<string, object> Verify([FromBody]VerifyModel model)
        {
            var isNullMessage = DigitalSignatureApiUtils.CheckForNull(model);
            if (isNullMessage != null)
            {
                return ResultManager.GetApiResult(
                        new SimpleResult
                        {
                            Code = 4,
                            Message = isNullMessage
                        }, "Json");
            }
            var verify = new Verify();
            try
            {
                model = DigitalSignatureApiUtils.DecodeVerifyModel(model);
                var verifyResult = VerifyData(model, verify);
                return ResultManager.GetApiResult(
                        new SimpleResult
                        {
                            Code = 0,
                            Data = new Dictionary<string, object> { { "Verification result", verifyResult } },
                            Message = "Successfully veryfied!"
                        }, "Json");
            }
            catch (CryptographicException)
            {
                return ResultManager.GetApiResult(
                      new SimpleResult
                      {
                          Code = 32,
                          Message = Constants.InvalidCertificateExMsg
                      }, "Json");
            }
            catch (FormatException)
            {
                return ResultManager.GetApiResult(
                    new SimpleResult
                    {
                        Code = 64,
                        Message = Constants.InvalidBase64ExMsg
                    }, "Json");
            }
        }

        private static string VerifyData(VerifyModel model, Verify verify)
        {
            return verify.VerifyFile(model.data, model.signature, model.cert)? Constants.VerifyCorrectMsg : Constants.VerifyIncorrectMsg;
        }
    }
}