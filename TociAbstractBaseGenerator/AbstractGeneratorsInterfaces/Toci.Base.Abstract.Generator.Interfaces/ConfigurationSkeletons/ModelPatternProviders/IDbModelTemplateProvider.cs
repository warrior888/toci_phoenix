using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders
{
    public interface IDbModelFilledTemplateProvider
    {       
        /// <summary>
        /// Gets the language of the template.
        /// </summary>
        /// <returns>The language enum that the template is written in.</returns>
        ModelProgrammingLanguage GetTemplateLanguage();

        /// <summary>
        /// Recognizes the pattern for the given language.
        /// </summary>
        /// <param name="tableConfig"></param>
        /// <param name="template"></param>
        /// <returns>Pattern for the given language</returns
        string FillTemplate(IDatabaseTableConfiguration tableConfig, IModelTemplate template);
    }
}