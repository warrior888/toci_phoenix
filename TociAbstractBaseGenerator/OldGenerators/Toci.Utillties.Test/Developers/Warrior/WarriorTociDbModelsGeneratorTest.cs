using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;
using Toci.Utilities.Test.Developers.Mg;

namespace Toci.Utilities.Test.Developers.Warrior
{
    [TestClass]
    public class WarriorTociDbModelsGeneratorTest
    {
        [TestMethod]
        public void WarriorTociModelsGeneratorTest()
        {
            var templateProvider = new DefaultModelTemplateProvider();

            templateProvider.NamespaceName = "Toci.Utilities.Test.Developers.Warrior.Destination";
            templateProvider.Parents = "Model";
  

           // templateProvider.BaseConstructorArguments = templateProvider.

            TociDbModelsGenerator modelsGenerator = new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), templateProvider));

            //modelsGenerator.GenerateModels(@"..\..\Developers\Warrior\data\ddlExample.txt", @"..\..\Developers\Warrior\Destination", ";", ",");
        }

        [TestMethod]
        public void Test3mbDdlGenerate()
        {
            var templateProvider = new DefaultModelTemplateProvider();

            templateProvider.NamespaceName = "_3mb.Dal.User";
            templateProvider.Parents = "Model";
            templateProvider.Usings = "Toci.Db.DbVirtualization";

            TociDbModelsGenerator modelsGenerator = new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), templateProvider));

            //modelsGenerator.GenerateModels(@"..\..\Developers\Warrior\data\ddlExample.txt", @"..\..\Developers\Warrior\Destination", ";", ",");
           /* modelsGenerator.GenerateModels(
                @"D:\self\trainings\Dropbox\Dropbox\3mb\code\3mb\3mb.Dal\3mb.Dal\3mb_Data_Ddl\3mb_base_Ddl.txt", 
                @"D:\self\trainings\Dropbox\Dropbox\3mb\code\3mb\3mb.Dal\3mb.Dal\User", 
                ";", ",");*/
            //D:\self\trainings\Dropbox\Dropbox\3mb\code\3mb\3mb.Dal\3mb.Dal\3mb_Data_Ddl\3mb_base_Ddl.txt
        }
    }
}
