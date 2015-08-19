using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Toci.DigitalSignature.DigitalSignHandlers;
using Toci.DigitalSignatureApi.Logic;
using Toci.DigitalSignatureApi.Models;
using Toci.ErrorsAndMessages.Abstraction;
using Toci.Utilities.Api;

namespace Toci.DigitalSignatureApi.Controllers
{
    public class SignController : TociApiController
    {
        [HttpPost]
        [Route("api/unsecuredsign")]
        public Dictionary<string, string> UnsecuredSign([FromBody]SignModel model)
        {
            var sign = new Sign();
            var isNullMessage = DigitalSignatureApiUtils.CheckForNull(model);
            if (isNullMessage != null)
            {
                return ResultManager.GetApiResult(
                        new SimpleResult
                        {
                            Code = 69,
                            Message = isNullMessage
                        }, "Json");
            }
            try
            {
                var resultData = HttpServerUtility.UrlTokenEncode(sign.SignFile(model.data, model.cert));
                return
                    ResultManager.GetApiResult(
                        new SimpleResult
                        {
                            Code = 0,
                            Data = new Dictionary<string, string> { { "signature", resultData } },
                            Message = "SuccessFully signed!"
                        }, "Json");
            }
            catch (CryptographicException)
            {
                return ResultManager.GetApiResult(
                      new SimpleResult
                      {
                          Code = 69,
                          Message = Constants.InvalidCertificateExMsg
                      }, "Json");
            }
            catch (FormatException)
            {
                return ResultManager.GetApiResult(
                      new SimpleResult
                      {
                          Code = 69,
                          Message = Constants.InvalidBase64ExMsg
                      }, "Json");
            }
        }

        [HttpPost]
        [Route("api/sign")]
        public Dictionary<string, string> Sign([FromBody]SecuredSignModel model)
        {
            var isNullMessage = DigitalSignatureApiUtils.CheckForNull(model);
            if (isNullMessage != null)
            {
                return ResultManager.GetApiResult(
                       new SimpleResult
                       {
                           Code = 69,
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
                           Data = new Dictionary<string, string> { { "signature", resultData } },
                           Message = "SuccessFully signed!"
                       }, "Json");

            }
            catch (CryptographicException)
            {

                return ResultManager.GetApiResult(
                      new SimpleResult
                      {
                          Code = 69,
                          Message = Constants.InvalidCertificateExMsg
                      }, "Json");
            }
            catch (FormatException)
            {
                return ResultManager.GetApiResult(
                     new SimpleResult
                     {
                         Code = 69,
                         Message = Constants.InvalidBase64ExMsg
                     }, "Json");
            }
        }
    }
}
