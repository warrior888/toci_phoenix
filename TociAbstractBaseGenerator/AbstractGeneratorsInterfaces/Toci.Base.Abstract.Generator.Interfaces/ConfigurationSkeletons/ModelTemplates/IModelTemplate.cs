namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelTemplates
{
    public interface IModelTemplate
    {
        string GetPropertyTemplate();

        /// <summary>
        /// Usings in c# and PHP
        /// </summary>
        /// <returns></returns>
        string GetHeaderTemplate();

        string GetClassTemplate();
    }
}