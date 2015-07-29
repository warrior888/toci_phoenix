using System;
using System.Collections.Generic;
using System.Data;
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
            var ModelListGenerator = new GenerateDbModelList<AddInModel,DbHandle>();


            var DbModelList = ModelListGenerator.GetDbModelList(itemModel, dbh);
            DbModelList.DDecryptDbModels();
            


            return View(DbUtils.SortListByTime(DbModelList));
        }
        
    }
}   