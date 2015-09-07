using System;
using System.Linq;
using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator.DbDdlParser;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser
{
    public class SqlDdlParser : DdlParser
    {
        private const int _shiftValue = 1;
        private const char _leftParenthesis = '(';
        private const char _rightParenthesis = ')';
        private const string _table = "TABLE";
        private const char _delimiter = ',';

        public SqlDdlParser(IDdlEntryParser ddlEntryParser) : base(ddlEntryParser)
        {
        }

        protected override string ExtractCoreDdl(string ddl)
        {
            int startPosition = ddl.ToUpper().IndexOf(_leftParenthesis) + _shiftValue; ;
            int endPosition = ddl.ToUpper().LastIndexOf(_rightParenthesis);
           
            var splittedString = (ddl.Substring(startPosition, endPosition - startPosition).Trim()).Split(_delimiter);
            return String.Join(_delimiter.ToString(), splittedString.Select(item => item.Trim()));
          
        }

        protected override string ExtractDdlTableName(string ddl)
        {
            int startPosition = ddl.ToUpper().IndexOf(_table) + _table.Length;
            int endPosition = ddl.ToUpper().IndexOf(_leftParenthesis) - _shiftValue;
            
                var extract = ddl.Substring(startPosition, endPosition - startPosition).Trim();
                return extract;

        }

        private string FirstLetterToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
