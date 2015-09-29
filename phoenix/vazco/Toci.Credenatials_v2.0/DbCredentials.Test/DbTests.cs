using System;
using System.Collections.Generic;
using DbCredentials.Bll.AutoMapper;
using DbCredentials.Bll.BusinessLogic;
using DbCredentials.Dal.GeneratedModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace DbCredentials.Test
{
    [TestClass]
    public class DbTests
    {

        [TestMethod]
        public void LoadScope()
        {
            AutoMapperConfiguration configuration= new AutoMapperConfiguration();
            ScopeModelLogic scopeLogic =new ScopeModelLogic();
            var result = scopeLogic.GetScopeModelByScopeName("scope");
        }

        [TestMethod]
        public void LoadProject()
        {
            AutoMapperConfiguration configuration = new AutoMapperConfiguration();
            ProjectModelLogic projectLogic = new ProjectModelLogic();
            var result = projectLogic.GetProjectModelByProjectName("projectname");
        }
        [TestMethod]
        public void AddScope()
        {
            AutoMapperConfiguration configuration = new AutoMapperConfiguration();
            ScopeModelLogic scopeLogic = new ScopeModelLogic();
            Scopes scope = new Scopes
            {
                ScopeName = "traktor2"
            };
            var result = scopeLogic.InsertScopeModel(scope);
        }

        [TestMethod]
        public void ModelsGenerator()
        {
            TociDbModelGeneratorWrapper generator = new TociDbModelGeneratorWrapper();
            IWrapperModel wrapperModel = new WrapperModel
            {
                ParentName = "Model",
                NamespaceName = "DbCredentials.Dal.GeneratedModels",
                UsingsList = new List<string>()
                {
                    "Toci.Db.DbVirtualization",
                    "Toci.Db.Interfaces"
                },
                TemplatePath = @"C:\Users\shass\Documents\toci_phoenix2\phoenix\vazco\Toci.Credenatials_v2.0\DbCredentials\DbCredentials\DbConfig\DataBase.txt",
                DestinationPath = @"..\..\..\DbCredentials.Dal\GeneratedModels",
                CsprojPath = @"..\..\..\DbCredentials.Dal\DbCredentials.Dal.csproj"
            };

            generator.GenerateModel(wrapperModel, "DbCredentials.Dal");
        }
    }
}
