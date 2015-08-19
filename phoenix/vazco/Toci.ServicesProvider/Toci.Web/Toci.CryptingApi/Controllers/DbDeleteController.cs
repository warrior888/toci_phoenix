using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCrypting;
using DbCrypting.VazcoDb;
using Toci.CryptingApi.Abstraction;
using Toci.CryptingApi.Exceptions;
using Toci.CryptingApi.Models;
using Toci.CryptingApi.ValidationUtils;
using Toci.Utilities.Api;
using Toci.Utilities.Common.Exceptions;

namespace Toci.CryptingApi.Controllers
{
    public class DbDeleteController : TociApiController
    {
        [Route("api/models/delete")]
        [HttpPost]
        
        public Dictionary<string, string> DeleteFromDb(BodyModel model)
        {
            try
            {
                var dbo = new DbOperations(model.password,new VazcoConfig());

                BodyModelValidation.Validate(model);

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

