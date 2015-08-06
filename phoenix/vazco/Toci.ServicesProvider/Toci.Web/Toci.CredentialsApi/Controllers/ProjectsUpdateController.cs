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
    public class ProjectsUpdateController : ApiController
    {
        [Route("Projects/Update")]
        //[HttpPost]
        [HttpPost]
        public int UpdateProjects(Model model, string columnname)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Update(model, columnname);
            }
            catch (Exception ex)
            {
                return default(int);
            }
        }
    }
}
