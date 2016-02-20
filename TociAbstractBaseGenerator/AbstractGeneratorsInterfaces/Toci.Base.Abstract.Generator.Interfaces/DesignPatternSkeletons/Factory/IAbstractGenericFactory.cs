using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Factory
{
    public interface IAbstractGenericFactory<TKey, TFactoredType>
    {
        /// <summary>
        /// Gets the dictionary of instances inside the Factory.
        /// </summary>
        /// <returns>Dictionary of instances in the factory.</returns>
        Dictionary<TKey, TFactoredType> GetAllnstances();
        /// <summary>
        /// Gets the instance for the given key
        /// </summary>
        /// <param name="key">Key to the instance</param>
        /// <returns>Instance</returns>
        TFactoredType GetInstance(TKey key);
    }
}