using System.Collections.Generic;

namespace Toci.Utilities.Interfaces
{
    public interface IParallelProcessing<TEntry, TResult>
    {
        List<TResult> RunParallelOperation(List<TEntry> entries, int threadsCount);
    }
}
