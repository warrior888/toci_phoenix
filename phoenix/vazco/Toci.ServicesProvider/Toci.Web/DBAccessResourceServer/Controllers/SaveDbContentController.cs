using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Logic;
using DBAccessResourceServer.Models;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;

namespace DBAccessResourceServer.Controllers
{
    public class SaveDbContentController : Controller
    {
        // GET: SaveDbContent
        private const string TableName = "LolTableMaster";


        public ActionResult SaveContent(DbModel model)
        {
            /*var dbh = DbConnect.Connect();
            var itemModel = new AddInModel(TableName);
            itemModel.SetGwiazdka();
            var dataset = DbUtils.DDecryptDbModels(DbUtils.GetPlainText(dbh, itemModel));*/
            model.data = "DUPA";// dataset[0].data;


            return View(model);
        }
    }
}