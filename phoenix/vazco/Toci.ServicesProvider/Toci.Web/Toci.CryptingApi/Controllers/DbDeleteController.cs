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
    public class DbDeleteController : ApiController
    {
        [Route("api/models/delete")]
        [HttpPost]
        
        public string DeleteFromDb(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password);
                dbo.Delete(new VazcoTable {id = model.id});

                return "Deleted!";
            }
            catch (Exception)
            {
                return "Bad Request!";
            }
        }
    }
}

