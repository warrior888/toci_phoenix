using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.Factory
{
    public class DbModelFilledTemplateProviderFactory<TKey, TValue> : AbstractGenericFactory<TKey, TValue>
    {
        public DbModelFilledTemplateProviderFactory(Dictionary<TKey, TValue> factoryDictionary) : base(factoryDictionary)
        {

        }

   
    }
}