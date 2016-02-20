namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons.ModelGenerationManagers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModelGenerationManager : IGenerationManager
    {
        /// <summary>
        /// open sql file
        /// get creates out of it
        /// put column info into classes/entitesIDatabseTableConfiguration
        /// create model in a given language - default c#
        /// save that to csproj
        /// recompile
        /// </summary>
        /// <returns></returns>
        bool ManageModelGeneration();
    }
}