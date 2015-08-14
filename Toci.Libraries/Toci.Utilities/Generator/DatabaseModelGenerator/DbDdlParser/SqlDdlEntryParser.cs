using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlEntryParser;

namespace Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser
{
    public class SqlDdlEntryParser : DdlEntryParser
    {
        public SqlDdlEntryParser()
        {
            TypeDictionary = new Dictionary<string, string>()
            {
                {"number","int"},
                {"serial","int"},
                {"integer","int"},
                {"int","int"},
                {"decimal","decimal"},
                {"double","double"},
                {"float","float"},
                {"varchar","string"},
                {"char","string"},
                {"text","string"},
                {"datetime","DateTime"},
                {"timestamp","DateTime"},
                {"time","DateTime"},
                {"date","DateTime"},
            };
        }
        

        protected override void GetFieldConstraints()
        {
            throw new NotImplementedException();
        }

        protected override sealed Dictionary<string, string> TypeDictionary { get; set; }
    }
}
