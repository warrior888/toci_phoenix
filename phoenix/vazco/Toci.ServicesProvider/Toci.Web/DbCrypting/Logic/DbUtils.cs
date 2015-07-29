using System.Collections.Generic;
using System.Linq;

namespace DbCrypting.Logic
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