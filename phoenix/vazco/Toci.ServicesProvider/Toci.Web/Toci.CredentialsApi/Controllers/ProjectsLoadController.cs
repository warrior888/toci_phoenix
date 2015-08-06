using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCredentials.DbLogic;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.CredentialsApi.Controllers
{
    public class ProjectsLoadController : ApiController
    {
        [Route("Projects/Load")]
        //[HttpPost]
        [HttpPost]
        public List<IModel> LoadProjects(Model model)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Load(model);
            }
            catch (Exception ex)
            {
                return default(List<IModel>);
            }
        }

        [Route("Projects/Load")]
        //[HttpPost]
        [HttpPost]
        public List<IModel> LoadProjects(Model model, string columnname)
        {
            try
            {
                DbQuery dbHandle = new DbQuery();
                return dbHandle.Load(model, columnname);
            }
            catch (Exception ex)
            {
                return default(List<IModel>);
            }
        }
    }
}
