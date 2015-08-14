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
                    Password = "jozinek123",
                    DbAdress = "localhost",
                    DbName = "philadelphia"
                })},
/*
                DbHandleAccessData.Password = "ph03n1x";
            DbHandleAccessData.DbAdress = "localhost";
            DbHandleAccessData.DbName = "Phoenix";
            DbHandleAccessData.UserName = "postgres";*/
                
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