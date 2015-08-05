using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;

namespace Toci.CryptingApi.Controllers
{
    public class DbDeleteController : ApiController
    {
        [Route("api/models/delete")]
        [HttpPost]
        
        public string DeleteFromDb([FromBody]string password,[FromBody]VazcoTable model)
        {
            var delete = new DbSave();
           // delete.Delete(model);

            return "Deleted!";
        }
    }
}

