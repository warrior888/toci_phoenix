using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;

namespace Toci.CryptingApi.Controllers
{
    public class DbSaveController : ApiController
    {
        [Route("api/models/save")]
        [HttpGet]
        public string SaveToDb([FromUri] DbModel model)
        {
            var save = new DbSave();
            save.Save(model);

            return "Saved!";
        }
    }
}
