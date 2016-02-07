using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Test.Developers.Warrior
{
    [TestClass]
    public class ModelGeneratorTest
    {
        [TestMethod]
        public void Generate()
        {
            TociDbModelGeneratorWrapper wrapper = new TociDbModelGeneratorWrapper();
            var wrapperModel = new WrapperModel();

            wrapperModel.CsprojPath = @"C:\self\toci\software\sourcetree\phoenix\TociAbstractBaseGenerator\Toci.RoyalSchool.Dal";
            wrapperModel.DestinationPath = @"C:\self\toci\software\sourcetree\phoenix\TociAbstractBaseGenerator\Toci.RoyalSchool.Dal";
            wrapperModel.FolderPath = "";
            wrapperModel.NamespaceName = "alamakota";
            wrapperModel.ParentName = "Model";
            wrapperModel.TemplatePath = @"C:\self\toci\software\sourcetree\phoenix\TociAbstractBaseGenerator\OldGenerators\Toci.Utillties.Test\Developers\Warrior\data\ddlExample.txt";
            //wrapperModel.UsingsList = "";

            wrapper.GenerateModel(wrapperModel, "Toci.RoyalSchool.Dal");
        }
    }
}