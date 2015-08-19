using System;
using System.Collections.Generic;
using System.Web;
using Toci.DigitalSignatureApi.Models;

namespace Toci.DigitalSignatureApi.Logic
{
    public static class DigitalSignatureApiUtils
    {
        public static string CheckForNull(object model)
        {
            List<string> message = new List<string>();
            var properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model, null) == null)
                    message.Add(property.Name);
            }

            return message.Count > 0 ? string.Join(" & ", message.ToArray()) + " field cannot be empty" : null;
        }

        public static SecuredSignModel DecodeSignModel(SecuredSignModel model)
        {
            model.cert = model.cert.Replace(' ', '+');
            return model;
        }
        public static VerifyModel DecodeVerifyModel(VerifyModel model)
        {
            model.cert = model.cert.Replace(' ', '+');
            model.signature = Convert.ToBase64String(HttpServerUtility.UrlTokenDecode(model.signature));
            return model;
        }
    }
}