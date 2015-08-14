using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlParser
{
    public abstract class DdlParser : IDdlParser
    {   
        protected IDdlEntryParser DdlEntryParser;
        private const int _minLength=0;
        protected DdlParser(IDdlEntryParser ddlEntryParser)
        {
            DdlEntryParser = ddlEntryParser;
        }

        public Dictionary<string, IDbFieldEntryEntity> GetFieldEntryEntities(string ddl, string separator, out string tableName)
        {
            if (ddl.Length > _minLength)
            {
                var coreddl = ExtractCoreDdl(ddl); // creat ( 'dfsag,fdsg' )
                tableName = ExtractDdlTableName(ddl);
                var ddlEntriesList = coreddl.Split(new[] {separator}, StringSplitOptions.None); // , fdagf,fda,fgads,fgds

                return
                    ddlEntriesList.Select(ddlEntry => DdlEntryParser.GetFieldEntryEntity(ddlEntry))
                        .ToDictionary(item => item.Name);
            }
            tableName = null;
            return null;
        }

        protected abstract string ExtractCoreDdl(string ddl);

        protected abstract string ExtractDdlTableName(string ddl);
    }
}
