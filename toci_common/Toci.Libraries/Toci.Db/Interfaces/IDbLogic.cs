namespace Toci.Db.Interfaces
{
    public interface IDbLogic
    {
        IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName);
    }
}