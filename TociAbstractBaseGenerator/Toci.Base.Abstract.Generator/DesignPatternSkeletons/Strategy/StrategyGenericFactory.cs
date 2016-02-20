using System;
using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Factory;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.Strategy
{
    public class StrategyGenericFactory<TKey, TFactoredType> : IAbstractGenericFactory<TKey, TFactoredType>
    {
        private readonly Dictionary<TKey, TFactoredType> factoryDictionary;

        public StrategyGenericFactory(Dictionary<TKey, TFactoredType> factoryDictionary)
        {
            if (factoryDictionary == null)
            {
                throw new ArgumentNullException("factoryDictionary");
            }

            this.factoryDictionary = factoryDictionary;
        }

        public Dictionary<TKey, TFactoredType> GetAllnstances()
        {
            return factoryDictionary;
        }

        public TFactoredType GetInstance(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return factoryDictionary.ContainsKey(key) ? factoryDictionary[key] : default(TFactoredType);
        }
    }
}