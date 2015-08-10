using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCredentials.DbLogic;
using Toci.Db.DbVirtualization;

namespace Toci.CredentialsApi.Controllers
{
    public class ProjectsSaveController : ApiController
    {

        [Route("Save/Project")]
        //[HttpPost]
        [HttpPost]
        public int SaveProjects(Model model)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Save(model);
            }
            catch (Exception )
            {
                return default(int);
            }
            
        }
    }
}
