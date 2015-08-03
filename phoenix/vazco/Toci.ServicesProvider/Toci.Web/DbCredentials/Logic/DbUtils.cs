using System.Collections.Generic;
using System.Linq;

namespace DbCredentials.Logic
{
    public class DbUtils
    {
        public static List<DbModel> SortListById(List<DbModel> list)
        {
            return list.OrderByDescending(x => x.Id).ToList();
        }
    }
}