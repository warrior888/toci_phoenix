namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelPatternProviders
{
    public interface IDbModelTemplateProvider
    {       
        /// <summary>
        /// Gets the language of the template.
        /// </summary>
        /// <returns>The language enum that the template is written in.</returns>
        ModelProgrammingLanguage GetTemplateLanguage();

        /// <summary>
        /// Recognizes the pattern for the given language.
        /// </summary>
        /// <param name="config">Table config</param>
        /// <returns>Pattern for the given language</returns
        string FillTemplatePattern(IDatabaseTableConfiguration tableConfig);
    }
}