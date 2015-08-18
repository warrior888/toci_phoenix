using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.DesignPatterns;

namespace Phoenix.Bll
{
    public class DbHandleAccessDataFactory : Factory<string,DbHandleAccessData>
    {
        public DbHandleAccessDataFactory()
        {
            FactoryDictionary = new Dictionary<string, Func<DbHandleAccessData>>()
            {
                {"Patryk",(() => new DbHandleAccessData()
                {
                    UserName = "postgres", 
                    Password = "team_leasing",
                    DbAdress = "localhost",
                    DbName = "philadelphia"
                })},

                
                {"Terry",(() => new DbHandleAccessData()
                {
                    UserName = "postgres", 
                    Password = "ph03n1x",
                    DbAdress = "localhost",
                    DbName = "Phoenix"
                })}
            };
        }
         
    }
}