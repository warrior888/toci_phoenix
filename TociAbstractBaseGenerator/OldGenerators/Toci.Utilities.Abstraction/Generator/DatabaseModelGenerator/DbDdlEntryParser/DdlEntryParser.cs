using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlEntryParser
{
    public abstract class DdlEntryParser : IDdlEntryParser
    {
        
        protected const char ColumnDefinitionDelimiter = ' ';

        public IDbFieldEntryEntity GetFieldEntryEntity(string column)
        {
             return new DbFieldEntryEntity() { Name = GetFieldName(column), FieldTypeName = GetFieldTypeName(column)};
        }

        protected virtual string GetFieldName(string column)
        {
            return column.Split(ColumnDefinitionDelimiter).First().ToLower();
        }
       
        protected virtual string GetFieldTypeName(string column)
        {
            return (from item in TypeDictionary where column.Contains(item.Key) select item.Value).FirstOrDefault();
        }

        //int integer datetime
        //protected abstract Type GetFieldType(string column); //int integer datetime, implement TypeDictionary usage here, make non abstract
    
        protected abstract void GetFieldConstraints();

        protected abstract Dictionary<string, string> TypeDictionary { get; set; }
    }
}
