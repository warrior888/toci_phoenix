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
                    UserName = "", 
                    Password = "",
                    DbAdress = "",
                    DbName = ""
                })},
                
                {"Terry",(() => new DbHandleAccessData()
                {
                    UserName = "", 
                    Password = "",
                    DbAdress = "",
                    DbName = ""
                })}
            };
        }
         
    }
}