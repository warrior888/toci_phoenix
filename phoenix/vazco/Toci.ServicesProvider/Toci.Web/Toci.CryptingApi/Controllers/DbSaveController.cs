using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;
using DbCrypting.VazcoDb;
using Toci.CryptingApi.Api;
using Toci.CryptingApi.Models;
using Toci.ErrorsAndMessages.Abstraction;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Exceptions;

namespace Toci.CryptingApi.Controllers
{
    public class DbSaveController : TTociApiController
    {
        [Route("api/models/save")]
        [HttpPost]
        public Dictionary<string, string> SaveToDb(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password, new VazcoConfig());
                dbo.Save(new VazcoTable {data = model.data,name = model.name});

                return ResultManager.GetApiResult(new SimpleResult { Code = 0, Message = "Saved!" }, "Json");
            }
            catch (UiTociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex), ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Save unsuccessfull." }, "Json");
            }
        }
    }
}
