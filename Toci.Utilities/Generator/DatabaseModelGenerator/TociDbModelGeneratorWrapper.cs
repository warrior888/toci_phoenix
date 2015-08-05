using System;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class TociDbModelGeneratorWrapper
    {
        private const string DdlItemsSeparator = ",";
        /// <summary>Generates a class *.cs, speicfied by the WrpaperModel</summary>
        public void GenerateModel(WrapperModel model)
        {
            const string colon = ";";
            const string usingString = "using ";
            var newline = string.Format("{0}{1}{2}", colon, Environment.NewLine, usingString);

            var template = new DefaultModelTemplateProvider
            {
                NamespaceName = model.NamespaceName,
                Parents = model.ParentName,
                Usings = string.Join(newline,model.UsingsList)
                //Usings = string.Format("{0}{1}{2}", "Toci.Db.DbVirtualization", newline, "Toci.Db.Interfaces")
            };




            var modelsGenerator =
                new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), template));

            modelsGenerator.GenerateModels(
                model.TemplatePath,
                model.DestinationPath, 
                colon,
                DdlItemsSeparator);
        }
    }
}