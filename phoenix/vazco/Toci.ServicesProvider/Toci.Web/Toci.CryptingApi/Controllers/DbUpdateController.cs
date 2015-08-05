using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;

namespace Toci.CryptingApi.Controllers
{
    public class DbUpdateController : ApiController
    {
        [Route("api/models/update")]
        [HttpPost]
        public string DeleteFromDb([FromBody]string password, [FromBody]VazcoTable model)
        {
            var update = new DbSave();
           // update.Update(model);

            return "Updated!";
        }
    }
}
