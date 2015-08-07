using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toci.CryptingApi.Controllers;
using Toci.CryptingApi.Models;

namespace Toci.CryptingFrontDemo.Controllers
{
    public class LoadController : Controller
    {
        private const string InvalidPasswordMsg = "Invalid password!";

        [HttpPost]
        public ActionResult Load(BodyModel model)
        {
            var dbLoad = new DbLoadController();
            var dbList = dbLoad.LoadDbModels(model).Where(x => x.data != InvalidPasswordMsg);
            if (model.password == default(string)) dbList = default(IEnumerable<BodyModel>);
            return View(    dbList     );
        }
    }
}