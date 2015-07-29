using System.Web.Mvc;
using DBAccessResourceServer.Models;
using Toci.DbImportantStuff.Logic;

namespace Toci.DbImportantStuff.Controllers
{
    public class DbSaveController: Controller
    {
        private const string TableName = "LolTableMaster";
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