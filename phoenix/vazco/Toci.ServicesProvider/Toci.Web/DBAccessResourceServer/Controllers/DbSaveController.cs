using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Models;
using EncodingLib;

namespace DBAccessResourceServer.Controllers
{
    public class DbSaveController : Controller
    {
        // GET: DbSave
        public ActionResult DbSaveResult(DbModel model)
        {
            model.addingTime = DateTime.Now;

            model.data = Crypting.EncryptStringAES(model.data, sharedSecret.secret);
            //TODO pobranie nicku usera && zapis do bazy DbHandle && custom key do szyfrowania
            model.nick = "Romuald test decrypt(testToDelete) : " + Crypting.DecryptStringAES(model.data, sharedSecret.secret);
            return View(model);
        }
    }
}