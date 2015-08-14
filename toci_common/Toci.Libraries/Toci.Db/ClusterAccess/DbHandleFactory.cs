using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.Clients;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;
using Toci.Db.Interfaces;

namespace Toci.Db.ClusterAccess
{
    public static class DbHandleFactory
    {
        public static IDbHandle GetHandle(SqlClientKind kind, string name, string password, string dbAddress, string dbName)
        {
            switch (kind)
            {
                case SqlClientKind.MsSql:
                    return new DbHandle(new MsSqlClient(name, password, dbAddress, dbName), new MsSqlSelect(), new MsSqlInsert(), new MsSqlUpdate(), new MsSqlDelete());
                case SqlClientKind.PostgreSql:
                    return new DbHandle(new PostgreSqlClient(name, password, dbAddress, dbName), new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete());
                default:
                    return null;
            }
        }
    }
}
