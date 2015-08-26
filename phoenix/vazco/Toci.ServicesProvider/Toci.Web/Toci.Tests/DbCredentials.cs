using System;
using System.Collections.Generic;
using DbCredentials.BusinessLogic;
using DbCredentials.Certificate;
using DbCredentials.Config;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.CredentialsApi.Models;
using Toci.Db.Clients;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Tests
{
    [TestClass]
    public class DbCredentials
    {
        private DbCredentials()
        {
            CertConfig.privateKeySecret = "P@ssw0rd";
            //certPath
            CertConfig.certPath =@"C:\Users\shass\Documents\toci_phoenix2\phoenix\vazco\Toci.ServicesProvider\Toci.Web\DbCredentials\Certificate\Certificate.pfx";
        }
        DbQuery dbQuery = new DbQuery(new DbConfig
        {
            //secret and dataBaseName
            secret = "localhost",
            address = "localhost",
            dataBaseName = "ImportantStuffDb",
            login = "postgres",
        });
        
        //[TestMethod]
        //public void AddProject()
        //{
        //    BusinessLogic business = new BusinessLogic(new VazcoDbConfig());
        //    ScopesLogic scopes = new ScopesLogic(new VazcoDbConfig());
        //    ProjectsLogic projects = new ProjectsLogic(new VazcoDbConfig());
        //    Scopes modScopes = new Scopes
        //    {
        //        scopename = "admin2"
        //    };
        //    Projects modProjects = new Projects
        //    {
        //        projectdata = "traktor",
        //        projectname = "taktak2",
        //        projectauthor = "S2yfr4nt",
        //    };
        //    var result = business.AddProject(modScopes, modProjects);



        //}

        //[TestMethod]
        //public void TestMethod1()
        //{
        //   //dbQuery = new DbQuery();
        //   // const string testString = "Test text";
        //   // Projects projmodel = new Projects();
        //   // var rreesult = dbQuery.Load(projmodel);

        //    Scopes model = new Scopes
        //    {
        //       // scopeid = 2,
        //        scopename = "Tralalaasfdsaf"
        //    };
        //    var rresult = dbQuery.Load(model, Scopes.SCOPEID);
        //   // model.SetWhere(Scopes.SCOPEID);
        //    dbQuery.Save(model);
        //    model.scopeid = 2;
        //    model.scopename = "kupczon";
        //    dbQuery.Update(model, Scopes.SCOPEID);
            
        //    var result = dbQuery.Load(model);
        //    model.scopeid = 1;
        //    model.scopename = "kupczon";
        //    dbQuery.Update(model, Scopes.SCOPEID);
        //    model = new Scopes();
        //    model.scopename = null;
        //    result = dbQuery.Load(model);
        //    ////////////////////////////////////////////

        //    Projects prmodel = new Projects
        //    {
        //        projectname = "dads",
        //        scopeid = 1,
        //        projectdata = "dsagfsgdh"
        //    };
        //    dbQuery.Save(prmodel);
        //    prmodel.projectid = 1;
        //    prmodel.scopeid = 2;
        //    prmodel.projectdata = "FSDSGSG";
        //    dbQuery.Update(prmodel,Projects.PROJECTID);
        //    result = dbQuery.Load(prmodel);
        //    prmodel = new Projects();
        //    result = dbQuery.Load(prmodel);
        //    //var anotherresult = dbQuery.Load(anothermodel).ToArray();
        //    //Assert.AreEqual(testString, r);
        //}

        [TestMethod]
        public void Save()
        {
            
            Scopes scmodel = new Scopes
            {
                scopename = "klekotmuchy"
            };
            var sth = dbQuery.Save(scmodel);

            Projects model = new Projects
            {
                projectname = "dads2",
                scopeid = 2,
                projectdata = "21d22e23sagfsgdh",
                projectauthor = "s2yfr4nt",
               // modificationdate = 
                //projectid = 2
            };
            ScopesLogic scopes = new ScopesLogic(new VazcoDbConfig());
            var result2 = scopes.IsScopeExist(scmodel);
            var result = dbQuery.Save(model); //, Projects.PROJECTID);
        }

        [TestMethod]
        public void Load()
        {
            Projects model = new Projects
            {
                //projectname = "dads",
                scopeid = 1,
                //projectdata = "dsagfsgdh",
                //projectauthor = "s2yfr4nt",
                // modificationdate = 
                //projectid = 1
            };
            //model.SetPrimaryKey(Projects.PROJECTID);
            var result = dbQuery.Load(model, Projects.SCOPEID); //, Projects.PROJECTID);
        }
        [TestMethod]
        public void LoadProjects()
        {
            Scopes model = new Scopes
            {
                
                scopename = "tralala",
                
            };
            Scopes model2 = new Scopes
            {
                
                scopename = "admin2",
                
            };
            ProjectsLogic logic = new ProjectsLogic(new VazcoDbConfig());
            var list = new List<Scopes> {model, model2};
            var result = logic.LoadProjects(list); //, Projects.PROJECTID);
        }

        [TestMethod]
        public void Update()
        {
            Projects model = new Projects
            {
                //projectname = "daadfsafgsdbds",
                //scopeid = 1,
                //projectdata = "dsagfsgdh",
                //hash = null,
                projectauthor = "s2yfr4nt1051",
                projectid = 1008
            };
            var result = dbQuery.Update(model, Projects.PROJECTID);
        }

        [TestMethod]
        public void Delete()
        {
            Projects model = new Projects
            {
               // projectname = "dads",
                //scopeid = 1,
                //projectdata = "dsagfsgdh",
                //hash = null,
                projectid = 1006
            };
            var result = dbQuery.Delete(model, Projects.PROJECTID);
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
            @"..\..\..\DbCredentials\CredentialsModels", ";", ",");
        }
    }
}