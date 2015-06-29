using Toci.Db.Interfaces;

namespace _3mb.Bll.Interfaces
{
    public interface IDbLogic
    {
        IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName);
    }
}