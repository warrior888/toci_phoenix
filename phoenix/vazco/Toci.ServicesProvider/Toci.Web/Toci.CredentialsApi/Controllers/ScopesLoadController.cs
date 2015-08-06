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
using Toci.Db.Interfaces;

namespace Toci.CredentialsApi.Controllers
{
    public class ScopesLoadController : ApiController
    {
        [Route("Scopes/Load")]
        //[HttpPost]
        [HttpPost]
        public List<IModel> LoadScopes(ScopesModel model)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Load(new Scopes
                {
                    scopeid = model.scopeId,
                    scopename = model.scopeName
                });
            }
            catch (Exception ex)
            {
                return default(List<IModel>);
            }
        }

        [Route("Scopes/Load")]
        //[HttpPost]
        [HttpPost]
        public List<IModel> LoadScopes(ScopesWhereModel model)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Load(new Scopes
                {
                    scopeid = model.scopeId,
                    scopename = model.scopeName
                }, 
                model.columnName);
            }
            catch (Exception ex)
            {
                return default(List<IModel>);
            }
        }
    }
}
