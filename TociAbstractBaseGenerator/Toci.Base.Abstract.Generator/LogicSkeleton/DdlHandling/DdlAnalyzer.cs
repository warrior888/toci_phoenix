using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling;

namespace Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling
{
    public class DdlAnalyzer : IDdlAnalyzer
    {
        private const char Separator = ';';
        private const string EscapeChars = "\r\n|\n|\t";

        public IList<string> GetAllTablesDdlsSeparated(string textFilePath)
        {
            var fileContent = File.ReadAllText(textFilePath);
            return GetAllTablesDdlsSeparatedFromString(fileContent);
        }

        public IList<string> GetAllTablesDdlsSeparatedFromString(string fileContent)//RoyalSchool/ddl/sql.sql
        {
            return Regex.Replace(fileContent, EscapeChars, string.Empty).Split(Separator).ToList();
        }
    }
}