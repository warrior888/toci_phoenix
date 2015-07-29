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
        static GenerateSecred GenerateSecret = new GenerateSecred("8a32d4v723s");
        private static List<object[]> GetTableContent(DbHandle dbh, Model model)
        {
            var dataSet = dbh.GetData(model);
            var tables = dataSet.Tables;
            var tmpList = new List<object[]>();
            var rows = tables[tables.Count - 1].Rows;
            if (rows.Count == 0) return null;
            for (var i = 0; i <= rows.Count - 1; i++)
            {
                var tmp = rows[i].ItemArray;
                tmpList.Add(tmp);
            }
            return tmpList;
        }

         public static List<DbModel> GetDbModelList(DbHandle dbh, Model model)
         {
             var list = GetTableContent(dbh, model);
             var resultList = new List<DbModel>();
             foreach (var item in list)
             {
                 resultList.Add(new DbModel { addingTime = (DateTime)item[2], data = (string)item[0], nick = (string)item[1] });
             }
             return resultList;
         }
        ///TODO od poparwy
         public static List<DbModel> GetPlainText(DbHandle dbh, Model model)
         {
            var list = GetTableContent(dbh, model);
            var resultList = new List<DbModel>();
            foreach (var item in list)
            {
                resultList.Add(new DbModel {  data = (string)item[0] });
            }
            return resultList;
        }

         public static List<DbModel> EncryptDbModels(List<DbModel> list)
         {

            foreach (var item in list)
            {
                item.data = new TociCrypting().DecryptStringAES(item.data, "8a32d4v723s", GenerateSecret.GetSecret());
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
            

            model.data = new TociCrypting().EncryptStringAES(model.data, "8a32d4v723s", GenerateSecret.GetSecret());
             
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