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

            wrapperModel.CsprojPath = @"C:\Users\bzapa\github\TociAbstractBaseGenerator\Toci.RoyalSchool.Dal";
            wrapperModel.DestinationPath = @"C:\Users\bzapa\github\TociAbstractBaseGenerator\Toci.RoyalSchool.Dal";
            wrapperModel.FolderPath = @"C:\Users\bzapa\github\TociAbstractBaseGenerator\Toci.RoyalSchool.Dal";
            wrapperModel.NamespaceName = "Toci.RoyalSchool.Dal";
            wrapperModel.ParentName = "Model";
            wrapperModel.TemplatePath = @"C:\Users\bzapa\github\TociAbstractBaseGenerator\OldGenerators\Toci.Utillties.Test\Developers\Warrior\data\ddlExample.txt";
            //wrapperModel.UsingsList = "";

            wrapper.GenerateModel(wrapperModel, "Toci.RoyalSchool.Dal");
        }
    }
}