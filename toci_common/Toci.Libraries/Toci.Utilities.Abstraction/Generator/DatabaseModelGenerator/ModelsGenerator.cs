using System;
using System.IO;
using Microsoft.Build.Evaluation;
using Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator;

namespace Toci.Utilities.Abstraction.Generator.DatabaseModelGenerator
{
    
    public abstract class ModelsGenerator : IModelsGenerator
    {
        protected string FileSavePattern = @"{0}\{1}.{2}";
        protected string ModelExtension;
        protected IModelGenerator ModelGenerator;

        protected ModelsGenerator(IModelGenerator modelGenerator)
        {
            ModelGenerator = modelGenerator;
        }           

        public void GenerateModels(IWrapperModel model, string separator, string ddlItemsSeparator)
        {
            using (StreamReader reader = new StreamReader(model.TemplatePath))
            {
                var secludedDdls = reader.ReadToEnd().Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                string className;
                var project = new Project(model.CsprojPath);

                foreach (var secludedDdl in secludedDdls)
                {
                    var classModel = ModelGenerator.GetModelClass(secludedDdl, ddlItemsSeparator, out className);
                    var fileSavePath = string.Format(FileSavePattern, model.DestinationPath, className, ModelExtension);

                    using (StreamWriter swr = new StreamWriter(fileSavePath))
                    {
                        swr.Write(classModel);
                        swr.Close();
                    }
                    project.AddItem("Compile", string.Format("{0}\\{1}.cs",model.FolderPath,className));
                }
                project.Save();
            }
        }

        public void GenerateModels(string path, string destinationPath, string separator, string ddlItemsSeparator)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var secludedDdls = reader.ReadToEnd().Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                string className;

                foreach (var secludedDdl in secludedDdls)
                {
                    var classModel = ModelGenerator.GetModelClass(secludedDdl, ddlItemsSeparator, out className);
                    var fileSavePath = string.Format(FileSavePattern, destinationPath, className, ModelExtension);

                    using (StreamWriter swr = new StreamWriter(fileSavePath))
                    {
                        swr.Write(classModel);
                        swr.Close();
                    }


                    //.cs
                }
            }
        }
    }
    
}
