using System;
using DbCredentials.CredentialsModels;
using DbCredentials.Logic;

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


            Scopes model = new Scopes
            {
                //scopeid = 2,
                scopename = "Tralalaasfdsaf"
            };
            var rresult = dbQuery.Load(model, Scopes.SCOPEID);
           // model.SetWhere(Scopes.SCOPEID);
            dbQuery.Save(model);
            model.scopeid = 2;
            model.scopename = "kupczon";
            dbQuery.Update(model, Scopes.SCOPEID);
            
            var result = dbQuery.Load(model);
            model.scopeid = 1;
            model.scopename = "kupczon";
            dbQuery.Update(model, Scopes.SCOPEID);
            result = dbQuery.Load(model);


            Projects prmodel = new Projects
            {
                projectname = "dads",
                scopeid = 1,
                projectdata = "dsagfsgdh"
            };
            dbQuery.Save(prmodel);
            prmodel.scopeid = 2;
            prmodel.projectdata = "FSDSGSG";
            dbQuery.Update(prmodel,Projects.PROJECTID);
            result = dbQuery.Load(prmodel);
            //var anotherresult = dbQuery.Load(anothermodel).ToArray();
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