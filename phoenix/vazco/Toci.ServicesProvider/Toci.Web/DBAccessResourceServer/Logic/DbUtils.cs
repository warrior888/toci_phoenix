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
             return list.Select(item => new DbModel {addingTime = (DateTime) item[2], data = (string) item[0], nick = (string) item[1], hash = (string) item[3]}).ToList();
         }

        ///TODO od poparwy
        /* public static List<DbModel> GetPlainText(DbHandle dbh, Model model)
         {
            var list = GetTableContent(dbh, model);
            return list.Select(item => new DbModel {data = (string) item[0]}).ToList();
         }*/

         

         public static string GetUserNick()
         {
             //TODO get user nick
             return "JanuszIT";
         }

         

         public static List<DbModel> SortListByTime(List<DbModel> list)
         {
             return list.OrderByDescending(x => x.addingTime).ToList();
         }
    }
}