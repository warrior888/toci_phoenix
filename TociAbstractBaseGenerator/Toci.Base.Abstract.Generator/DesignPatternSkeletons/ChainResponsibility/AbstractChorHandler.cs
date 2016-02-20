using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.ChainResponsibility;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Strategy;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.ChainResponsibility
{
    public abstract class AbstractChorHandler : IChorHandler
    {
        public void Run(IAbstractGenericStrategy strategy, IRefTypeEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}