using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.User;
using Toci.Db.ClusterAccess;
using Toci.Utilities.Interfaces.DependencyResolve;
using Toci.Utilities.Interfaces.DesignPatterns;
using _3mb.Bll.Essential;
using _3mb.Bll.Interfaces.User;

namespace Phoenix.Integration.Test.Developers.Warrior.DependencyResolve
{
    [TestClass]
    public class DependencyResolveTest
    {
        protected static IFactory<DependencyResolverType, IDependencyResolver> DependencyResolverFactory = new DependencyResolverFactory();
        protected static IDependencyResolver DependencyResolver = DependencyResolverFactory.Create(DependencyResolverType.Autofac);

        [TestMethod]
        public void TestDependencyResolve()
        {
            var logic = DependencyResolver.Resolve<IUserLogic>();

            Assert.IsInstanceOfType(logic, typeof(UserLogic));
        }

        [TestMethod]
        public void TestDbHandleDependencyResolve()
        {
            var bllDbLogic = new BllDbLogic();

            var dbHandle = bllDbLogic.GetDbHandle("test", "test", "localhost", "test");
            
            Assert.IsInstanceOfType(dbHandle, typeof(DbHandle));
        }
    }
}
