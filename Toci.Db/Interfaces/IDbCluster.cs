using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Db.Interfaces
{
    public interface IDbCluster
    {
        IDbClient GetClient(string id, IDbSharding sharding);
    }
}
