using System;
using Toci.Utilities.Generator.DatabaseModelGenerator.DbDdlParser;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Generator.DatabaseModelGenerator
{
    public class TociDbModelGeneratorWrapper
    {
        private const string DdlItemsSeparator = ",";
        const string Colon = ";";
        const string UsingString = "using ";
        /// <summary>Generates a class *.cs, speicfied by the WrpaperModel</summary>
        
        public void GenerateModel(IWrapperModel model, string dllName)
        {
            var template = GenerateTemplateProvider(model);
            var modelsGenerator = new TociDbModelsGenerator(new TociDbModelGenerator(new SqlDdlParser(new SqlDdlEntryParser()), template));

            FillWrapperModel(model, dllName);
            modelsGenerator.GenerateModels(model,Colon, DdlItemsSeparator);
        }

        private IModelTemplateProvider GenerateTemplateProvider(IWrapperModel model)
        {
            var newline = string.Format("{0}{1}{2}", Colon, Environment.NewLine, UsingString);

            return new DefaultModelTemplateProvider
            {
                NamespaceName = model.NamespaceName,
                Parents = model.ParentName,
                //Usings = string.Join(newline, model.UsingsList)
                Usings = string.Format("{0}{1}{2}", "Toci.Db.DbVirtualization", newline, "Toci.Db.Interfaces")
            };
        }

        private void FillWrapperModel(IWrapperModel model, string dllName)
        {
            var splitProjectPath = model.DestinationPath.Split(new [] {dllName + @"\\"}, StringSplitOptions.None);
            model.CsprojPath = string.Format("{0}{1}\\{1}.csproj", splitProjectPath[0],dllName);// ??????
            model.FolderPath = @"C:\self\toci\software\sourcetree\phoenix\TociAbstractBaseGenerator\OldGenerators\Toci.Utillties.Test\Developers\Warrior\Destination";//  splitProjectPath[1];
        }
    }
}