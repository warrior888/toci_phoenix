using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.ChainResponsibility;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Strategy;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.ChainResponsibility
{
    public abstract class AbstractChorManager : IChorManager
    {
        public IDictionary<string, IChorHandler> GetHandlersDictionary()
        {
            

            throw new System.NotImplementedException();
        }

        public void Run(IAbstractGenericStrategy strategy, IRefTypeEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}