using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlEntryParser
{
    public abstract class DdlEntryParser : IDdlEntryParser
    {
        
        protected const char ColumnDefinitionDelimiter = ' ';

        public IDbFieldEntryEntity GetFieldEntryEntity(string column)
        {
             return new DbFieldEntryEntity() { Name = GetFieldName(column), FieldType = GetFieldType(column)};
        }

        protected virtual string GetFieldName(string column)
        {
            return column.Split(ColumnDefinitionDelimiter).First().ToLower();
        }
       
        protected virtual Type GetFieldType(string column)
        {
            return (from item in TypeDictionary where column.Contains(item.Key) select item.Value()).FirstOrDefault();
        }

        //int integer datetime
        //protected abstract Type GetFieldType(string column); //int integer datetime, implement TypeDictionary usage here, make non abstract
    
        protected abstract void GetFieldConstraints();

        protected abstract Dictionary<string, Func<Type>> TypeDictionary { get; set; }
    }
}
