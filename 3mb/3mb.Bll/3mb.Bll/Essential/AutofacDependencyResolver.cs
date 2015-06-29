using Toci.Utilities.Interfaces.DependencyResolve;

namespace _3mb.Bll.Essential
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        public TService Resolve<TService>(params object[] parameters)
        {
            return AutofacContainer.GetContainer().Resolve<TService>(parameters);
        }
    }
}