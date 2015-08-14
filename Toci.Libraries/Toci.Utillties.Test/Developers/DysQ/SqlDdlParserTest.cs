using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Test.Developers.DysQ
{
    public class SqlDdlParserToTest : SqlDdlParser
    {
        public SqlDdlParserToTest(IDdlEntryParser ddlEntryParser) : base(ddlEntryParser)
        {
        }

        public string getExtractCoreMethodPossibilities(string command)
        {
            return this.ExtractCoreDdl(command);
        }
    }
    [TestClass]
    public class SqlDdlParserTest 
    {
        [TestMethod]
        public void ExtractCoreDysqTest()
        {
            SqlDdlParserToTest test = new SqlDdlParserToTest(new SqlDdlEntryParserTest());
            var emptystringTest = test.getExtractCoreMethodPossibilities("");
            var showMeTestResult = test.getExtractCoreMethodPossibilities(@"create table test (
	id serial primary key,
	nazwa text, 
    email text
)");
        }
    }
}
