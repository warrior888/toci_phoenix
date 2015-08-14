using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces;

namespace Toci.Utilities.Abstraction.Parallelism
{
    public abstract class ParallelProcessing<TEntry, TResult> : IParallelProcessing<TEntry, TResult>
    {
        private readonly object _lockObject = new object();

        protected List<TResult> Results;

        public virtual List<TResult> RunParallelOperation(List<TEntry> entries, int threadsCount)
        {
            entries.AsParallel().WithDegreeOfParallelism(threadsCount).ForAll(AtomicOperation);

            return Results;
        }

        protected virtual void AtomicOperation(TEntry entry)
        {
            var item = ProcessEntry(entry);

            lock (_lockObject)
            {
                Results.Add(item);
            }
        }

        protected abstract TResult ProcessEntry(TEntry entry);
    }
}
