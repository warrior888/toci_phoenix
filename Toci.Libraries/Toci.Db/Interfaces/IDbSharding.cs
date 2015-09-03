namespace Toci.Db.Interfaces
{
    public interface IDbSharding
    {
        IDbClient GetShard(string id);
    }
}
