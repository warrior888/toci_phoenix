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