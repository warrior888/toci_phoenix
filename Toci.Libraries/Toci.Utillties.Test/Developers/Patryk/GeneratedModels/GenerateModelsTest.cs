using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Test.Developers.Patryk.GeneratedModels
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
                NamespaceName = "Phoenix.Dal.Models",
                UsingsList = new List<string>()
                {
                    "Toci.Db.DbVirtualization",
                    "Toci.Db.Interfaces"
                },
                TemplatePath = @"..\..\Developers\Patryk\GeneratedModels\Sql\generateModels.txt",
                DestinationPath = @"..\..\..\..\..\phoenix\phoenix.Dal\Phoenix.Dal\Models",
            };

            generator.GenerateModel(wrapperModel,"Phoenix.Dal");
       }             
    }
}