
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;


namespace Phoenix.Integration.Test.Developers.Patryk.DbTests
{
    [TestClass]
    public class GenerateModelsTest
    {
        [TestMethod]
        public void GenerateModels()
        {
            TociDbModelGeneratorWrapper generator = new TociDbModelGeneratorWrapper();
            IWrapperModel wrapperModel = new WrapperModel
            {
                ParentName = "Model",
                NamespaceName = "Phoenix.Dal.GeneratedModels",
                UsingsList = new List<string>()
                {
                    "Toci.Db.DbVirtualization",
                    "Toci.Db.Interfaces"
                },
                TemplatePath = @"C:\Users\ksebal\Desktop\sql.txt",
                DestinationPath = @"..\..\..\..\phoenix.Dal\Phoenix.Dal\generatedKsebal",
            };

            generator.GenerateModel(wrapperModel,"Phoenix.Dal");
       }             
    }
}