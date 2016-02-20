using System;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.ChainResponsibility;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Strategy;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.ChainResponsibility
{
    public abstract class AbstractChorHandler : IChorHandler
    {
        public void Run(IAbstractGenericStrategy strategy, IRefTypeEntity entity)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }


        }
    }
}