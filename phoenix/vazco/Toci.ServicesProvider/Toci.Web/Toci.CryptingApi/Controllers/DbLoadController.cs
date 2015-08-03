using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;

namespace Toci.CryptingApi.Controllers
{
    public class DbLoadController : ApiController
    {
        private const string empty = "";
        [Route("api/models/load")]
        [HttpGet]
        public IEnumerable<DbModel> LoadDbModels(string name=empty)
        {
            var load = new DbLoad();

            return name != empty ? load.Load().Where(x => x.nick == name) : load.Load();
        }

    }
}
