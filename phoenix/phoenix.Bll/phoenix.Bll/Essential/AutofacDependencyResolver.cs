using Toci.Utilities.Interfaces.DependencyResolve;
using _3mb.Bll.Essential;

namespace Phoenix.Bll.Essential
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        public TService Resolve<TService>(params object[] parameters)
        {
            return AutofacContainer.GetContainer().Resolve<TService>(parameters);
        }
    }
}