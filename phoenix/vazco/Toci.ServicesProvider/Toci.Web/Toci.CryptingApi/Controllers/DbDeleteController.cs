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
using Toci.CryptingApi.ValidationUtils;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Exceptions;

namespace Toci.CryptingApi.Controllers
{
    public class DbDeleteController : TTociApiController
    {
        [Route("api/models/delete")]
        [HttpPost]
        
        public Dictionary<string, object> DeleteFromDb(BodyModel model)
        {
            try
            {
                BodyModelValidation.ValidateId(model);

                var dbo = new DbOperations(model.password,new VazcoConfig());


                dbo.Delete(new VazcoTable {id = model.id});

                return ResultManager.GetApiResult(new SimpleResult {Code = 0, Message = "Deleted!"}, "Json");
            }
            catch (UiTociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex), ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Delete unsuccessfull." }, "Json");
            }
        }
    }
}

