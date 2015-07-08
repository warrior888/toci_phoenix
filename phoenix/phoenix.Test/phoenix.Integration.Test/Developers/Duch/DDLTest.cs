using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Phoenix.Integration.Test.Developers.Duch
{
    [TestClass]
    public class DdlTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            const string colon = ";";
            const string usingString = "using ";
            var newline = string.Format("{0}{1}{2}", colon, Environment.NewLine,usingString);

            var template = new DefaultModelTemplateProvider
            {
                NamespaceName = "Phoenix.Dal.GeneratedModels",
                Parents = "Model",
                Usings = string.Format("{0}{1}{2}", "Toci.Db.DbVirtualization", newline, "Toci.Db.Interfaces")
            };




            var modelsGenerator = new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), template));

            modelsGenerator.GenerateModels(
                @"..\..\Developers\Duch\data\test.txt",
               // @"..\..\Developers\Duch\destination",
                @"..\..\..\..\phoenix.Dal\Phoenix.Dal\GeneratedModels",
                ";", ",");
        }
    }
}
