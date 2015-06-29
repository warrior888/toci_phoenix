namespace Toci.Utilities.Interfaces.DesignPatterns
{
    public interface IFactory<in TIndexer, out TResult>
    {
        TResult Create(TIndexer indexer);
    }
}