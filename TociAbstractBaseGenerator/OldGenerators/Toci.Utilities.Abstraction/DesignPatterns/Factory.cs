using System;
using System.Collections.Generic;
using Toci.Utilities.Interfaces.DesignPatterns;

namespace Toci.Utilities.Abstraction.DesignPatterns
{
    public abstract class Factory<TIndexer, TResult> : IFactory<TIndexer, TResult>
    {
        protected Dictionary<TIndexer, Func<TResult>> FactoryDictionary;

        public TResult Create(TIndexer indexer)
        {
            if (FactoryDictionary.ContainsKey(indexer))
            {
                return FactoryDictionary[indexer]();
            }

            throw new ArgumentException(string.Format("FactoryDictionary does not have {0} index defined", indexer));
        }
    }
}
