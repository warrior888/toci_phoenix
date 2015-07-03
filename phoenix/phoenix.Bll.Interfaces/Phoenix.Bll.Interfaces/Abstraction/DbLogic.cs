using Phoenix.Bll.Interfaces;
using Toci.Db.Interfaces;

namespace _3mb.Bll.Interfaces.Abstraction
{
    public abstract class DbLogic : Logic, IDbLogic
    {
        protected IDbHandle DbHandle;

        public abstract IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName);
    }
}