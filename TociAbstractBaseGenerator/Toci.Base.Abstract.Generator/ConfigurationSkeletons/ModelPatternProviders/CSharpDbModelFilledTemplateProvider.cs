using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelPatternProviders
{
    public class CSharpDbModelFilledTemplateProvider : DbModelFilledTemplateProvider
    {
        public override ModelProgrammingLanguage GetTemplateLanguage()
        {
            return ModelProgrammingLanguage.CSharp;
        }

        public override string FillTemplate(IDatabaseTableConfiguration tableConfig, IModelTemplate template)
        {
            // iterate tableConfig.TableColumns

            return null;
        }
    }
}