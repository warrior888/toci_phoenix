using System;
using System.Collections.Generic;
using System.Linq;
using DBAccessResourceServer.Models;
using EncodingLib;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;

namespace DBAccessResourceServer.Logic
{
     static class DbUtils
    {
        public static List<DbModel> GetLastArrayFromDb(DbHandle dbh, Model model)
        {
            var dataSet = dbh.GetData(model);
            var tables = dataSet.Tables;
            var tmpList = new List<DbModel>();
            var rows = tables[tables.Count - 1].Rows;
            if (rows.Count == 0) return null;
            for (var i = 0; i <= rows.Count - 1; i++)
            {
                var tmp = rows[i].ItemArray.ToList();
                tmpList.Add(new DbModel { addingTime = (DateTime)tmp[2], data = (string)tmp[0], nick = (string)tmp[1] });
            }
            return tmpList;
        }

         public static List<DbModel> EncryptDbModels(List<DbModel> list)
         {
            foreach (var item in list)
            {
                item.data = Crypting.DecryptStringAES(item.data, sharedSecret.secret);
            }

            
            return SortListByTime(list);
        }

         private static string GetUserNick()
         {
             //TODO get user nick
             return "JanuszIT";
         }

         public static void DecryptModel(this DbModel model)
         {
             model.data = Crypting.EncryptStringAES(model.data, sharedSecret.secret);
             
         }

         public static void FillAddInModel(this AddInModel itemModel,DbModel model)
         {
            itemModel.SetNick(DbUtils.GetUserNick());
            itemModel.SetData(model.data);
            itemModel.SetTime(DateTime.Now);
        }

         private static List<DbModel> SortListByTime(List<DbModel> list)
         {
             return list.OrderByDescending(x => x.addingTime).ToList();
         }
    }
}