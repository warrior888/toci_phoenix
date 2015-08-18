using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;
using DbCrypting.VazcoDb;
using Toci.CryptingApi.Models;

namespace Toci.CryptingApi.Controllers
{
    public class DbUpdateController : ApiController
    {
        [Route("api/models/update")]
        [HttpPost]
        public string Update(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password, new VazcoConfig());
                dbo.Update(new VazcoTable {id = model.id,addingTime = model.addingTime,data = model.data,name = model.name});

                return "Updated!";
            }
            catch (Exception)
            {
                return "Bad Request!";
            }
        }
    }
}
