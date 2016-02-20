using System;
using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Factory;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.Factory
{
    public abstract class AbstractGenericFactory<TKey,TValue>:IAbstractGenericFactory<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> factoryDictionary;

        public AbstractGenericFactory(Dictionary<TKey, TValue> factoryDictionary)
        {
            if (factoryDictionary == null)
            {
                throw new ArgumentException("factoryDictionary");
            }

            this.factoryDictionary = factoryDictionary;
        }

        public virtual Dictionary<TKey, TValue> GetAllnstances()
        {
            return factoryDictionary;
        }

        public virtual TValue GetInstance(TKey key)
        {
            return factoryDictionary.ContainsKey(key) ? factoryDictionary[key] : default(TValue);
        }
    }
}