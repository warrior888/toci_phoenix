using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.CredentialsApi.Models;
using Toci.Db.DbVirtualization;

namespace Toci.CredentialsApi.Controllers
{
    public class ScopesUpdateController : ApiController
    {
        [Route("Scopes/Update")]
        //[HttpPost]
        [HttpPost]
        public int UpdateScopes(ScopesWhereModel model)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Update(new Scopes
                {
                    scopeid = model.scopeId, 
                    scopename = model.scopeName
                },
                model.columnName);
            }
            catch (Exception ex)
            {
                return default(int);
            }
        }
    }
}
