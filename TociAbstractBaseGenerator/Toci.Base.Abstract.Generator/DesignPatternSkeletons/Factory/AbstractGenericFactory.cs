using System;
using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Factory;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.Factory
{
    public abstract class AbstractGenericFactory<TKey, TFactoredType> : IAbstractGenericFactory<TKey, TFactoredType>
    {
        private readonly Dictionary<TKey, TFactoredType> factoryDictionary;

        protected AbstractGenericFactory() 
        {

        }

        protected AbstractGenericFactory(Dictionary<TKey, TFactoredType> factoryDictionary)
        {
            if (factoryDictionary == null)
            {
                throw new ArgumentNullException("the given factoryDictionary is null");
            }

            this.factoryDictionary = factoryDictionary;
        }

        public virtual Dictionary<TKey, TFactoredType> GetAllnstances()
        {
            return factoryDictionary;
        }

        public virtual TFactoredType GetInstance(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("The given key is null");
            }

            return factoryDictionary.ContainsKey(key) ? factoryDictionary[key] : default(TFactoredType);
        }
    }
}