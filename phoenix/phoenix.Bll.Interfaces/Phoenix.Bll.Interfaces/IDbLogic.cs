using Toci.Db.Interfaces;

namespace Phoenix.Bll.Interfaces
{
    public interface IDbLogic
    {
        IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName);
    }
}