using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;
using Toci.DigitalSignatureApi.Abstraction;
using Toci.DigitalSignatureApi.Logic;
using Toci.DigitalSignatureApi.Models;
using Toci.Utilities.Api;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class SignController : TmpDsTociApiController
    {

        [HttpPost]
        [Route("api/sign")]
        public Dictionary<string, object> Sign([FromBody]SecuredSignModel model)
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
            var sign = new Sign();
            try
            {
                model = DigitalSignatureApiUtils.DecodeSignModel(model);
                var resultData =
                    HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data,
                        sign.PfxFileToCertificate(model.cert, model.password)));
                return
                   ResultManager.GetApiResult(
                       new SimpleResult
                       {
                           Code = 0,
                           Data = new Dictionary<string, object> { { "signature", resultData } },
                           Message = "SuccessFully signed!"
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
    }
}
