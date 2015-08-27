using Toci.Db.Interfaces;

namespace toci.pentagram.interfaces
{
    public interface IDbLogic
    {
        IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName);
    }
}