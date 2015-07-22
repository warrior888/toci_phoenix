using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Toci.DigitalSignatureWebApi.Controllers
{

    public class InputFileController : ApiController
    {
        [HttpPost]
        public string GetFileInput(HttpPostedFile file)
        {
            if (file == null || file.ContentLength < 1) return string.Empty;

            var reader = new BinaryReader(file.InputStream);
            var input = reader.ReadBytes(file.ContentLength);

            return Convert.ToBase64String(input);

        }
    }
}
