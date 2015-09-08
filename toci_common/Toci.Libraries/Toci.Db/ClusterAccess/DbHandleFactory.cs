using System;
using System.Collections.Generic;
using Toci.Db.Clients;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;
using Toci.Db.Interfaces;

namespace Toci.Db.ClusterAccess
{
    public static class DbHandleFactory
    {
        private static Dictionary<SqlClientKind, Func<DbAccessConfig, IDbHandle>> dbHandleFactory
            = new Dictionary<SqlClientKind, Func<DbAccessConfig, IDbHandle>>
            {
                {
                    SqlClientKind.MsSql, (config) => new DbHandle(
                        new MsSqlClient(config.UserName, config.Password, config.DbAddress, config.DbName),
                        new MsSqlSelect(), new MsSqlInsert(), new MsSqlUpdate(), new MsSqlDelete())
                },
                {
                    SqlClientKind.PostgreSql, (config) => new DbHandle(
                        new PostgreSqlClient(config.UserName, config.Password, config.DbAddress, config.DbName), 
                        new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete())
                }
            };

        public static IDbHandle GetHandle(DbAccessConfig config)
        {
            return dbHandleFactory.ContainsKey(config.ClientKind) ? dbHandleFactory[config.ClientKind](config) : null;
        }
    }
}
