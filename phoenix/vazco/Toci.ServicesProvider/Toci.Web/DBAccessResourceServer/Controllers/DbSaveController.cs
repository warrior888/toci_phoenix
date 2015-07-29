using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Logic;
using DBAccessResourceServer.Models;
using EncodingLib;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.MsSqlQuery;

namespace DBAccessResourceServer.Controllers
{
    public class DbSaveController : Controller
    {
        // GET: DbSave
        //TODO pobranie nicku usera && custom key do szyfrowania

        private const string TableName = "LolTable";

        public ActionResult DbSaveResult(DbModel model)
        {
            var itemModel = new AddInModel(TableName);
            var dbh = DbConnect.Connect();

            model.DecryptModel();
            itemModel.FillAddInModel(model);
            dbh.InsertData(itemModel);

            
            //mock to delete
            model.nick = "Romuald test decrypt(testToDelete) : " + new TociCrypting().DecryptStringAES(model.data, "8a32d4v723s");
            //endof
            return View(model);
        }
    }
}