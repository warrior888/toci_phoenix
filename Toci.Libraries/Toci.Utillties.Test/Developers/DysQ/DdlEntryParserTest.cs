using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Test.Developers.DysQ
{
    public class SqlDdlEntryParserTest : SqlDdlEntryParser
    {
        public Type SqlDdlEntryParserTypeTest(string columnToTest)
        {
            return this.GetFieldType(columnToTest);
        }
    }
    [TestClass]
    public class DdlEntryParserDysqTest
    {
      
        [TestMethod]
        public void DdlEntryParserMethodTest()
        {
            SqlDdlEntryParserTest test = new SqlDdlEntryParserTest();

            var firstTestStringType = test.SqlDdlEntryParserTypeTest("text 'name'");
            var secondTestStringType = test.SqlDdlEntryParserTypeTest("nvarchar 'name'");
            var testIntType = test.SqlDdlEntryParserTypeTest("integer 'id'");
            var testDoubleType = test.SqlDdlEntryParserTypeTest("decimal 'price'");
            var testDateType = test.SqlDdlEntryParserTypeTest("datetime '2015-04-16 22:22:22'");

        }
    }
}
