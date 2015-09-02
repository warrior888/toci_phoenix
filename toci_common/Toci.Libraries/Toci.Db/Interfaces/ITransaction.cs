using System;
using System.Collections.Generic;

namespace Toci.Db.Interfaces
{
    public interface ITransaction
    {
        void RunQueries(List<Func<IDbHandle, Func<bool>, int>> queriesList);
    }
}
