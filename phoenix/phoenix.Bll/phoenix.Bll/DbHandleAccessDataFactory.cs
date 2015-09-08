using System;
using System.Collections.Generic;
using Toci.Db.ClusterAccess;
using Toci.Utilities.Abstraction.DesignPatterns;

namespace Phoenix.Bll
{
    public class DbHandleAccessDataFactory : Factory<string, DbAccessConfig>
    {
        public DbHandleAccessDataFactory()
        {
            FactoryDictionary = new Dictionary<string, Func<DbAccessConfig>>()
            {
                {"Patryk",(() => new DbAccessConfig()
                {
                    UserName = "postgres", 
                    Password = "postgres",
                    DbAddress = "localhost",
                    DbName = "philadelphia",
                    ClientKind = SqlClientKind.PostgreSql

                })},

                
                {"Terry",(() => new DbAccessConfig()
                {
                    UserName = "postgres", 
                    Password = "ph03n1x",
                    DbAddress = "localhost",
                    DbName = "Phoenix",
                    ClientKind = SqlClientKind.PostgreSql
                })}
            };
        }
         
    }
}