using System;
using DbCredentials.Logic;
using DbCredentials.Logic.DbModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Tests
{
    [TestClass]
    public class DbCredentials
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbQuery = new DbQuery();
           // const string testString = "Test text";


            DbScopesModel model = new DbScopesModel { ScopeID = 1, ScopeName = "Tralala" };

            dbQuery.Save(model, "Scopes");
            var result = dbQuery.Load("Scopes");
            //Assert.AreEqual(testString, r);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string colon = ";";
            const string usingString = "using ";
            var newline = string.Format("{0}{1}{2}", colon, Environment.NewLine, usingString);

            var template = new DefaultModelTemplateProvider
            {
                NamespaceName = "DbCredentials.CredentialsModels",
                Parents = "Model",
                Usings = string.Format("{0}{1}{2}", "Toci.Db.DbVirtualization", newline, "Toci.Db.Interfaces")
            };




            var modelsGenerator = new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), template));

            modelsGenerator.GenerateModels(
                @"..\..\..\DbCredentials\Config\DataBase.txt",
                // @"..\..\Developers\Duch\destination",
                @"..\..\..\DbCredentials\CredentialsModels",";", ",");
        }
    }
}