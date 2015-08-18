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
    public class DbLoadController : ApiController
    {
        private const string WrongPassword = "Invalid password!";
        [Route("api/models/load")]
        [HttpPost]
        public IEnumerable<BodyModel> LoadDbModels(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password, new VazcoConfig());
                var vazcoList =  dbo.Load();
                return vazcoList.Select(item => new BodyModel
                {
                    addingTime = item.addingTime, data = item.data, id = item.id, name = item.name
                }).Where(x => x.data != WrongPassword).ToList();
                //return model.name != default(string) ? dbo.Load().Where(x => x.name == model.name) : dbo.Load();

            }
            catch (Exception)
            {
                return default(IEnumerable<BodyModel>);
            }
        }

    }
}
