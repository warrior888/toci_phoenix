namespace Toci.Utilities.Interfaces.DependencyResolve
{
    public interface IDependencyResolver
    {
        TService Resolve<TService>(params object[] parameters);
    }
}