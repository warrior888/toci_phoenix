using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Tests
{
    [TestClass]
    public class ModelGeneratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            const string colon = ";";
            const string usingString = "using ";
            var newline = string.Format("{0}{1}{2}", colon, Environment.NewLine, usingString);

            var template = new DefaultModelTemplateProvider
            {
                NamespaceName = "DbCrypting",
                Parents = "Model",
                Usings = string.Format("{0}{1}{2}", "Toci.Db.DbVirtualization", newline, "Toci.Db.Interfaces")
            };




            var modelsGenerator = new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), template));

            modelsGenerator.GenerateModels(
                @"..\..\..\DbCrypting\VazcoDb\template.txt",
                // @"..\..\Developers\Duch\destination",
                @"..\..\..\DbCrypting\VazcoDb\", ";", ",");

        }
    }
}
