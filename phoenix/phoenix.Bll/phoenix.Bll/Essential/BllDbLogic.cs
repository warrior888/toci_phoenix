using Phoenix.Bll.Essential;
using Toci.Db.ClusterAccess;
using Toci.Db.Interfaces;
using Toci.Utilities.Interfaces.DependencyResolve;
using Toci.Utilities.Interfaces.DesignPatterns;
using _3mb.Bll.Interfaces.Abstraction;

namespace _3mb.Bll.Essential
{
    public class BllDbLogic : DbLogic
    {
        //TODO in fact this should be in BllLogic class not db ...
        protected static IFactory<DependencyResolverType, IDependencyResolver> DependencyResolverFactory = new DependencyResolverFactory();
        protected static IDependencyResolver DependencyResolver = DependencyResolverFactory.Create(DependencyResolverType.Autofac);

        public override IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
            DbHandle = DependencyResolver.Resolve<IDbHandle>(
                DependencyResolver.Resolve<IDbClient>(user, password, dbAddress, dbName),
                DependencyResolver.Resolve<ISelect>(),
                DependencyResolver.Resolve<IInsert>(),
                DependencyResolver.Resolve<IUpdate>(),
                DependencyResolver.Resolve<IDelete>()
                );

            return DbHandle;
        }
    }
}