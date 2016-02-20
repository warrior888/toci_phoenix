using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.Factory
{
    public class DbModelFilledTemplateProviderFactory<TKey, TValue> : AbstractGenericFactory<TKey, TValue>
    {

 
        public DbModelFilledTemplateProviderFactory(Dictionary<TKey, TValue> factoryDictionary) : base(factoryDictionary)
        {

        }
    }
}