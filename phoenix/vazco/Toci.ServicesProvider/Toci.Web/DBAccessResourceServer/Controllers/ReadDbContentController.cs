using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBAccessResourceServer.Models;
using EncodingLib;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;

namespace DBAccessResourceServer.Controllers
{
    public class ReadDbContentController : Controller
    {
        // GET: ReadDbContent
        public ActionResult LoadContent(DbModel model)
        {
         /*   //TODO db request for model
            
            model.data = "text text text text text ";
            model.nick = "Gerwazy";
            model.addingTime = new DateTime(2013,10,1,15,15,15);
            var mock1 = new DbModel();
            var mock2 = new DbModel();
            mock1.nick = "Andrzej";
            mock2.nick = "Romuald";
            mock1.data = "asdasdasdadsa sa dsa sd asd a sd asd a sda d a s asd";
            mock2.data = "ukukiukukiu kuy ik uy iku ik yu kiyu ki uy";
            mock1.addingTime = new DateTime(2013, 10, 1, 15, 15, 15);
            mock2.addingTime = new DateTime(2013, 10, 1, 15, 15, 15);

            var mockList = new List<DbModel>
            {
                model,
                mock1,
                mock2
            };
            //end of ToDelete */


            var dbh = DbConnect.Connect();
            var itemModel = new AddInModel("LolTable");
           
            itemModel.SetGwiazdka();

            var dataset = GetLastArrayFromDb(dbh, itemModel);
           foreach (var item in dataset)
           {
               item.data = Crypting.DecryptStringAES(item.data, sharedSecret.secret);
            }

            //model.data = Crypting.DecryptStringAES(model.data, sharedSecret.secret);

            return View(dataset);
        }
        private List<DbModel> GetLastArrayFromDb(DbHandle dbh,Model model)
        {
            var dataSet = dbh.GetData(model);
            var tables = dataSet.Tables;
            var tmpList= new List<DbModel>();
            var rows = tables[tables.Count - 1].Rows;
            if (rows.Count == 0) return null;

            //return rows[rows.Count - 1].ItemArray.ToList();
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                var tmp = rows[i].ItemArray.ToList();
                tmpList.Add(new DbModel {addingTime = (DateTime)tmp[2],data = (string)tmp[0],nick = (string)tmp[1]}  );
            }
            return tmpList;
        }
    }
}