using System.Collections.Generic;
using System.Linq;

namespace DbCrypting.Logic
{
     static class DbUtils
    {
        
         public static string GetUserNick()
         {
             //TODO get user nick
             return "VazcoTeam";
         }

        public static List<VazcoTable> SortListByTime(List<VazcoTable> list)
        {
            return list.OrderByDescending(x => x.addingTime).ToList();
        }
    }
}