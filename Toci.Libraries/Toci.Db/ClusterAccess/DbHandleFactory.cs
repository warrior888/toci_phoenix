using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Remoting.Messaging;
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

        public static IDbHandle GetHandle(SqlClientKind kind, string name, string password, string dbAddress, string dbName)
        {
            DbAccessConfig config = new DbAccessConfig
            {
                UserName = name,
                Password = password,
                DbAddress = dbAddress,
                DbName = dbName
            };
            return GetHandle(kind, config);
            //Stara wersja kodu zosaje zakomentowana, poniewaz nie ma testów 
            //            switch (kind)
            //            {
            //                case SqlClientKind.MsSql:
            //                    return new DbHandle(new MsSqlClient(name, password, dbAddress, dbName), new MsSqlSelect(), new MsSqlInsert(), new MsSqlUpdate(), new MsSqlDelete());
            //                case SqlClientKind.PostgreSql:
            //                    return new DbHandle(new PostgreSqlClient(name, password, dbAddress, dbName), new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete());
            //                default:
            //                    return null;
            //            }
        }

        public static IDbHandle GetHandle(SqlClientKind kind, DbAccessConfig config)
        {
            return dbHandleFactory.ContainsKey(kind) ? dbHandleFactory[kind](config) : null;
        }

    }
}
