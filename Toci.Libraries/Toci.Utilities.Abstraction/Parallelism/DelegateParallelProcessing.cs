using System;

namespace Toci.Utilities.Abstraction.Parallelism
{
    public class DelegateParallelProcessing<TEntry, TResult> : ParallelProcessing<TEntry, TResult>
    {
        private readonly Func<TEntry, TResult> _processEntryDelegate;

        public DelegateParallelProcessing(Func<TEntry, TResult> processEntryDelegate)
        {
            _processEntryDelegate = processEntryDelegate;
        }

        protected override TResult ProcessEntry(TEntry entry)
        {
            return _processEntryDelegate(entry);
        }
    }
}
