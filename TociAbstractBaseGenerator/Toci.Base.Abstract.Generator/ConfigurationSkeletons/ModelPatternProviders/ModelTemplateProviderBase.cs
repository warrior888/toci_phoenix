using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelPatternProviders
{
    public abstract class ModelTemplateProviderBase : IDbModelTemplateProvider
    {
        public abstract ModelProgrammingLanguage GetTemplateLanguage();
        public abstract string FillTemplatePattern(IDatabaseTableConfiguration tableConfig);
    }
}