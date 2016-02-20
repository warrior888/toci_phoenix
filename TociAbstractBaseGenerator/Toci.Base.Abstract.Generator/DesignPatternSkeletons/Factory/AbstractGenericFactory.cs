using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Toci.Base.Abstract.Generator.Interfaces.DesignPatternSkeletons.Factory;

namespace Toci.Base.Abstract.Generator.DesignPatternSkeletons.Factory
{
    public abstract class AbstractGenericFactory<TKey, TFactoredType> : IAbstractGenericFactory<TKey, TFactoredType>
    {
        private readonly Dictionary<TKey, TFactoredType> factoryDictionary;

        protected AbstractGenericFactory() 
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Dictionary<Type, Func<TFactoredType>> dictionary = new Dictionary<Type, Func<TFactoredType>>();
            foreach (var assembly in assemblies)
            {
                foreach (var classObject in assembly.GetTypes().Where(key => key.IsClass && !key.IsAbstract && key.IsSubclassOf(typeof(AbstractGenericFactory<TKey, TFactoredType>))))
                {
                    dictionary.Add(classObject, new Func<TFactoredType>(() => (TFactoredType)Activator.CreateInstance(classObject)));
                }
            }

            
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