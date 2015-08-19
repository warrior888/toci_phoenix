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
    public class DbLoadController : TociApiController
    {
        private const string WrongPassword = "Invalid password!";
        [Route("api/models/load")]
        [HttpPost]
        public Dictionary<string, string> LoadDbModels(BodyModel model)
        {
            //ApiSimpleResultManager man = new ApiSimpleResultManager();
            try
            {
                var dbo = new DbOperations(model.password, new VazcoConfig());
                var vazcoList =  dbo.Load();
                var resultList = vazcoList.Select(item => new BodyModel
                {
                    addingTime = item.addingTime, data = item.data, id = item.id, name = item.name
                }).Where(x => x.data != WrongPassword).ToList();

                var result = new SimpleResult
                {Code = 0, Message = "Loaded!"};

                foreach (var item in resultList)
                {
                    result.Data.Add("Id",item.id.ToString());
                    result.Data.Add("Adding Time",item.addingTime.ToString());
                    result.Data.Add("Name",item.name);
                    result.Data.Add("Data", item.data);

                }

                return ResultManager.GetApiResult(result, "Json");
                
            }
            catch (UiTociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex), ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Load unsuccessfull." }, "Json");
            }
        }

    }
}
