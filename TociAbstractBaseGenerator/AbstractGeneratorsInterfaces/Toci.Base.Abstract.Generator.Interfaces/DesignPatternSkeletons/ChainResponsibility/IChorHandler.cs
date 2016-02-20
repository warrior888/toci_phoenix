using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Strategy;

namespace Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.ChainResponsibility
{
    public interface IChorHandler
    {
        /// <summary>
        /// Run single CHOR action
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="entity"></param>
        void Run(IAbstractGenericStrategy strategy, IRefTypeEntity entity);
    }
}