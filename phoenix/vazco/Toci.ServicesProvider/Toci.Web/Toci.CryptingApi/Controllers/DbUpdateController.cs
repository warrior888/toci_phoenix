using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;
using DbCrypting.VazcoDb;
using Toci.CryptingApi.Models;
using Toci.ErrorsAndMessages.Abstraction;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Exceptions;

namespace Toci.CryptingApi.Controllers
{
    public class DbUpdateController : TociApiController
    {
        [Route("api/models/update")]
        [HttpPost]
        public Dictionary<string, string> Update(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password, new VazcoConfig());
                dbo.Update(new VazcoTable {id = model.id,addingTime = model.addingTime,data = model.data,name = model.name});

                return ResultManager.GetApiResult(new SimpleResult { Code = 0, Message = "Updated!" }, "Json");
            }
            catch (UiTociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex), ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Update unsuccessfull." }, "Json");
            }
        }
    }
}
