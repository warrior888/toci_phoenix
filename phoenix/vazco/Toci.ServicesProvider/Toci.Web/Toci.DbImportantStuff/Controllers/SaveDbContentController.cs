using System.Web.Mvc;
using DBAccessResourceServer.Models;

namespace Toci.DbImportantStuff.Controllers
{
    public class SaveDbContentController: Controller
    {
        // GET: SaveDbContent
        private const string TableName = "ImportantStuffDb";


        public ActionResult SaveContent(DbModel model)
        {
            /*var dbh = DbConnect.Connect();
            var itemModel = new AddInModel(TableName);
            itemModel.SetGwiazdka();
            var dataset = DbUtils.EncryptDbModels(DbUtils.GetPlainText(dbh, itemModel));*/
            model.data = "DUPA";// dataset[0].data;


            return View(model);
        }
    }
}