using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace Toci.DigitalSignatureWebApi.Controllers
{

    public class DigitalSignatureController : ApiController
    {
        [HttpPost]
        public byte[] GetPfxFile(HttpPostedFile file)
        {
            if (file == null || file.ContentLength < 1) return new byte[0];

            var reader = new BinaryReader(file.InputStream);
            var result = Convert.ToBase64String(reader.ReadBytes(file.ContentLength));

            return ExecuteSignMethod(result,/*nie wiem jak tu przekazać inne parametry*/ new SecureString(), new byte[0]);
        }

        public byte[] ExecuteSignMethod(string base64String, SecureString password, byte[] content)
        {
            Sign signatureProvider = new Sign();
            var cert = signatureProvider.PfxFileToCertificate(base64String, password);
            return signatureProvider.SignFile(content, cert);
        }


    }
}
