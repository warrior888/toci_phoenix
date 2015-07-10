using Phoenix.Bll.Interfaces;
using Toci.Db.Interfaces;

namespace Phoenix.Bll
{
    public abstract class DbLogic : IDbLogic
    {
        protected IDbHandle DbHandle;

        protected DbLogic()
        {
            //DbHandle = GetDbHandle();
        }

        public IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
            // podac obiekt pracujacy z baza danych
            throw new System.NotImplementedException();
        }
    }
}