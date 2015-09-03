using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.DesignPatterns;

namespace toci.pentagram.bll.dblogic
{
    public class DbHandleAccessDataFactory : Factory<string, DbHandleAccessData>
    {
        public DbHandleAccessDataFactory()
        {
            FactoryDictionary = new Dictionary<string, Func<DbHandleAccessData>>
            {
                {"Patryk",(() => new DbHandleAccessData
                {
                    UserName = "postgres",
                    Password = "team_leasing",
                    DbAdress = "localhost",
                    DbName = "philadelphia"
                })},
                {"ksebal",(() => new DbHandleAccessData
                {
                    UserName = "postgres",
                    Password = "konrad",
                    DbAdress = "localhost",
                    DbName = "phonix"
                })}

            };
        }

    }
}