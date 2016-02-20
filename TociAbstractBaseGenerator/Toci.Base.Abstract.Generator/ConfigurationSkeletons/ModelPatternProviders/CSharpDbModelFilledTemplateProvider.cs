using Toci.Base.Abstract.Generator.ConfigurationSkeletons.ModelPatternProviders;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders
{
    public class CSharpDbModelFilledTemplateProvider : DbModelFilledTemplateProvider
    {

        public override ModelProgrammingLanguage GetTemplateLanguage()
        {
            throw new System.NotImplementedException();
        }

        public virtual string FillTemplatePattern(IDatabaseTableConfiguration tableConfig)
        {
            throw new System.NotImplementedException();
        }
    }
}