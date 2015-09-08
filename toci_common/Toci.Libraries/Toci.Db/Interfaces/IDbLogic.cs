using Toci.Db.ClusterAccess;

namespace Toci.Db.Interfaces
{
    public interface IDbLogic
    {
        IDbHandle GetDbHandle(DbAccessConfig config);
    }
}