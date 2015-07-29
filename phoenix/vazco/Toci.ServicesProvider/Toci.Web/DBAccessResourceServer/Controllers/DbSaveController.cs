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

        private const string LogTableName = "LolTable";

        public ActionResult DbSaveResult(DbModel model)
        {
            var LogModel = new AddInModel(LogTableName);
            var dbh = DbConnect.Connect();


            model.EncryptModel();
            LogModel.FillAddInModel(model);
            dbh.InsertData(LogModel);


            return View(model);
        }
    }
}