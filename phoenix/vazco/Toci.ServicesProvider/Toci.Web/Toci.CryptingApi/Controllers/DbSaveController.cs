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
    public class DbSaveController : ApiController
    {
        [Route("api/models/save")]
        [HttpPost]
        public string SaveToDb(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password);
                dbo.Save(new VazcoTable {data = model.data,name = model.name});

                return "Saved!";
            }
            catch (Exception)
            {
                return "Bad Request!";
            }
        }
    }
}
