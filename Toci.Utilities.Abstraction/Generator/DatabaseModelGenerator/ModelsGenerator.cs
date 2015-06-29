using System;
using System.IO;
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
                             // ddl -> create y ; katalog gdzie sa klasy   -> ; <-                  > , <
        public void GenerateModels(string path, string destinationPath, string separator, string ddlItemsSeparator)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var secludedDdls = reader.ReadToEnd().Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
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
                }
            }
        }
    }
}
