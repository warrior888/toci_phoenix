using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.MsSqlQuery;

namespace DBAccessResourceServer.Logic
{
    static class DbConnect
    {
        private const string login = "sa";
        private const string secret = "KurwaKurwa";
        private const string address = "localhost";
        private const string dataBaseName = "TestBase";

        public static DbHandle Connect()
        {
            var client = new MsSqlClient(login, secret, address, dataBaseName);
            return new DbHandle(client, new MsSqlSelect(), new MsSqlInsert(), new MsSqlUpdate(), new MsSqlDelete());
        }
    }
}