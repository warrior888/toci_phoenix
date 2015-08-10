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
    public class ScopesSaveController : ApiController
    {
        [System.Web.Http.Route("Scopes/Save")]
        //[HttpPost]
        [System.Web.Http.HttpPost]
        public int SaveScopes(ScopesModel model)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Save(new Scopes{scopename = model.scopeName});
            }
            catch (Exception ex)
            {
                return default(int);
            }

        }


        //public ActionResult Create( 
        //Person person,
        //[Bind(Prefix="Person.PersonDetails")]
        //PersonDetails details,
        //[Bind(Prefix="Person.PersonDetails.ContactInformation")] 
        //ContactInformation[] info )
        //{
        //      person.PersonDetails = details;
        //      person.PersonDetails.ContactInformation = info;

        //      ...
        //}
    }
}
