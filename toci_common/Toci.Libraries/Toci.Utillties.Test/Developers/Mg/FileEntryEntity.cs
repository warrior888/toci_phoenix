using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlEntryParser;

namespace Toci.Utilities.Test.Developers.Mg
{
    [TestClass]
    public class PostgreEntries : DdlEntryParser
    {
     
        [TestMethod]
        public void FileEntry()
        {
            var z = GetFieldEntryEntity("id integer not null");

        }

        public PostgreEntries()
        {
            TypeDictionary = new Dictionary<string, Func<Type>>();
            
        }
            protected override Type GetFieldType(string column)
            {
                //logic
                string fieldType = "integer".ToUpper();
                return postgreDic[fieldType]();
            }

            protected override void GetFieldConstraints()
            {
                throw new NotImplementedException();
            }

            protected sealed override Dictionary<string, Func<Type>> TypeDictionary { get; set; }
      

        private Dictionary<string, Func<Type>> postgreDic = new Dictionary<string, Func<Type>>()
            {
                {"INTEGER", () => typeof (int)},
                {"VARCHAR", () => typeof (string)},
                {"MONEY", () => typeof (decimal)}
            };

          

    }
}
