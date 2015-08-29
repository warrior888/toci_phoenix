using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MvcFormPostClient.Models;
using Newtonsoft.Json;
using Sample;
using System.Windows.Data.Json;
namespace MvcFormPostClient.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult CreateProject(ProjectModel model)
        {
            JsonObject jsonObject = new JsonObject();
            
            StringContent content = new StringContent(result.ToString());
            var client = new HttpClient();
            client.PostAsync(Constants.VazcoApi+"Save/Project",content);

            return Redirect("View.cshtml");
        }
    }
}