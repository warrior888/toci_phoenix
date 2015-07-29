using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.MsSqlQuery;

namespace Toci.DbImportantStuff.Logic
{
    public class DbConnect
    {
        private const string login = "sa";
        private const string secret = "lcoalhost";
        private const string address = "localhost";
        private const string dataBaseName = "ImportantStuffDb";

        public static DbHandle Connect()
        {
            var client = new MsSqlClient(login, secret, address, dataBaseName);
            return new DbHandle(client, new MsSqlSelect(), new MsSqlInsert(), new MsSqlUpdate(), new MsSqlDelete());
        } 
    }
}