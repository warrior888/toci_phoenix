using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.DesignPatterns;
using Toci.Utilities.Interfaces.DependencyResolve;

namespace Phoenix.Bll.Essential
{
    public class DependencyResolverFactory : Factory<DependencyResolverType, IDependencyResolver>
    {
        public DependencyResolverFactory()
        {
            FactoryDictionary = new Dictionary<DependencyResolverType, Func<IDependencyResolver>>()
            {
                { DependencyResolverType.Autofac, () => new AutofacDependencyResolver() }
            };
        }
    }
}