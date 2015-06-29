using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlEntryParser;

namespace Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser
{
    public class SqlDdlEntryParser : DdlEntryParser
    {
        public SqlDdlEntryParser()
        {
            TypeDictionary = new Dictionary<string, Func<Type>>()
        {
            {"number",() => typeof(int)},
            {"serial",() =>typeof(int)},
            {"integer",() => typeof(int)},
            {"int",() =>typeof(int)},
            {"decimal",()=>typeof(decimal)},
            {"double",() =>typeof(double)},
            {"float",() =>typeof(float)},
            {"varchar",() =>typeof(string)},
            {"char",() =>typeof(string)},
            {"text",() =>typeof(string)},
            {"datetime",() =>typeof(DateTime)},
            {"timestamp",() =>typeof(DateTime)},
            {"time",() =>typeof(DateTime)},
            {"date",() =>typeof(DateTime)},
        };
        }
        

        protected override void GetFieldConstraints()
        {
            throw new NotImplementedException();
        }

        protected override sealed Dictionary<string, Func<Type>> TypeDictionary { get; set; }
    }
}
