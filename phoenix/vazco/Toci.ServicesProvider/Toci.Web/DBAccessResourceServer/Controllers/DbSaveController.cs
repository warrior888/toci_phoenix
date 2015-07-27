using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult DbSaveResult(DbModel model)
        {
            var itemModel = new AddInModel("LolTable");
            var dbh = DbConnect.Connect();

            model.data = Crypting.EncryptStringAES(model.data, sharedSecret.secret);

            

            itemModel.SetNick("JanuszIT");
            itemModel.SetData(model.data);
            itemModel.SetTime(DateTime.Now);

            dbh.InsertData(itemModel);
            
           


            model.nick = "Romuald test decrypt(testToDelete) : " + Crypting.DecryptStringAES(model.data, sharedSecret.secret);
            return View(model);
        }
    }
}