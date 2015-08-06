using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toci.CredentialsApi.Models;

namespace Toci.CredentialsApi.Controllers
{
    public class CredentialsController : ApiController
    {
        [Route("Credentials/Save")]
        ///[HttpPost]
        [HttpGet]
        public void SaveCredentials(DbEntryModel model)
        {
            
        }
    }
}
