using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCredentials.DbLogic;
using Toci.CredentialsApi.Models;
using Toci.Db.DbVirtualization;

namespace Toci.CredentialsApi.Controllers
{
    public class ProjectsDeleteController : ApiController
    {
        [Route("Projects/Delete")]
        //[HttpPost]
        [HttpPost]
        public int DeleteProjects(Model model, string columnname)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Delete(model, columnname);
            }
            catch (Exception ex)
            {
                return default(int);
            }
        }
    }
}
