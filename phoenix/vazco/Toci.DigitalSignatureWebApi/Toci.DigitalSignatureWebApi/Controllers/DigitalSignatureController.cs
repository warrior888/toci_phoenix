using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace Toci.DigitalSignatureWebApi.Controllers
{

    public class DigitalSignatureController : ApiController
    {
        [HttpPost]
        [Route("api/DigitalSignatureController/GetPfxFile")]
        public byte[] GetPfxFile(string content, HttpPostedFile file, string password)
        {
            if (file == null || file.ContentLength < 1) return new byte[0];

            var reader = new BinaryReader(file.InputStream);
            var result = Convert.ToBase64String(reader.ReadBytes(file.ContentLength));
            var securepass = new SecureString();
            foreach (var c in password.ToCharArray())
            {
                securepass.AppendChar(c);
            }
            return ExecuteSignMethod(result, securepass, Encoding.ASCII.GetBytes(content));
        }

        public byte[] ExecuteSignMethod(string base64String, SecureString password, byte[] content)
        {
            Sign signatureProvider = new Sign();
            var cert = signatureProvider.PfxFileToCertificate(base64String, password);
            return signatureProvider.SignFile(content, cert);
        }
        
    }
}
