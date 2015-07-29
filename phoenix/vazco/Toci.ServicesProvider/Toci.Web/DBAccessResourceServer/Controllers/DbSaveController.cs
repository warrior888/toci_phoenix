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

        private const string TableName = "";
        private const string LogTableName = "LolTable";

        public ActionResult DbSaveResult(DbModel model)
        {
            var LogModel = new AddInModel(LogTableName);
            var itemModel = new AddInModel(TableName);
            var dbh = DbConnect.Connect();


            model.DecryptModel();
            itemModel.AddIsWhere("id", "1", true);

            LogModel.FillAddInModel(model);
            itemModel.SetData(model.data);
            dbh.UpdateData(itemModel);
            dbh.InsertData(LogModel);


            //mock to delete
            //model.nick = "Romuald test decrypt(testToDelete) : " + Crypting.DecryptStringAES(model.data, sharedSecret.secret);
            //endof
            return View(model);
        }
    }
}