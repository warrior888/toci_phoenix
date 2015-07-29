using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Logic;
using DBAccessResourceServer.Models;
using EncodingLib;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;

namespace DBAccessResourceServer.Controllers
{
    public class ReadDbContentController : Controller
    {

        private const string TableName = "LolTable";

        public ActionResult LoadContent(DbModel model)
        {

            var dbh = DbConnect.Connect();
            var itemModel = new AddInModel(TableName);
            itemModel.SetGwiazdka();

            var dataset = DbUtils.GetDbModelList(dbh, itemModel);
            dataset.DDecryptDbModels();
            


            return View(DbUtils.SortListByTime(dataset));
        }
        
    }
}   