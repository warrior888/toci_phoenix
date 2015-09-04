namespace Toci.Db.Interfaces
{
    public interface IDbCluster
    {
        IDbClient GetClient(string id, IDbSharding sharding);
    }
}
