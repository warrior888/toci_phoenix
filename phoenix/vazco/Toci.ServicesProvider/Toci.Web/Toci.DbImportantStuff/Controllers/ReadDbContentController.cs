using System.Web.Mvc;
using DBAccessResourceServer.Models;
using Toci.DbImportantStuff.Logic;

namespace Toci.DbImportantStuff.Controllers
{
    public class ReadDbContentController: Controller
    {
        private const string TableName = "LolTable";

        public ActionResult LoadContent(DbModel model)
        {

            var dbh = DbConnect.Connect();
            var itemModel = new AddInModel(TableName);
            itemModel.SetGwiazdka();

            var dataset = DbUtils.EncryptDbModels(DbUtils.GetDbModelList(dbh, itemModel));



            return View(dataset);
        }
    }
}