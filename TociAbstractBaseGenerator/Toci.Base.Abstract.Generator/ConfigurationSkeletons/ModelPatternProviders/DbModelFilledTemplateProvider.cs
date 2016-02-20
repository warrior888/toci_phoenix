using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelPatternProviders
{
    public abstract class DbModelFilledTemplateProvider : IDbModelFilledTemplateProvider
    {
        public abstract ModelProgrammingLanguage GetTemplateLanguage();
        public abstract string FillTemplate(IDatabaseTableConfiguration tableConfig, IModelTemplate template);
    }
}