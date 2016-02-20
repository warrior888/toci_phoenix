using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelTemplates
{
    public abstract class ModelTemplateBase : IModelTemplate
    {
        public abstract string GetPropertyTemplate();
        public abstract string GetHeaderTemplate();
        public abstract string GetClassTemplate();
    }
}