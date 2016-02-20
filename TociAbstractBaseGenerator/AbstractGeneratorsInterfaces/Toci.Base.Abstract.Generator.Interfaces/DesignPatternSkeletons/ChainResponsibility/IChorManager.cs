using System.Collections;
using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Strategy;

namespace Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.ChainResponsibility
{
    public interface IChorManager
    {
        /// <summary>
        /// Gets handlers dictionary for chain responsiblity
        /// </summary>
        IDictionary<string, IChorHandler> GetHandlersDictionary();

        /// <summary>
        /// Run strategies on the entity
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="entity"></param>
        void Run(IAbstractGenericStrategy strategy, IRefTypeEntity entity);
    }
}