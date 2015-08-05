using DbCrypting.Config;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.MsSqlQuery;

namespace DbCrypting.Logic
{
    static class DbConnect
    {
        private static readonly string login;
        private static readonly string secret;
        private static readonly string address;
        private static readonly string dataBaseName;

        static DbConnect()
        {
            login = LoadConfig.login;
            secret = LoadConfig.secret;
            address = LoadConfig.address;
            dataBaseName = LoadConfig.DataBaseName;
        }

        public static DbHandle Connect()
        {
            var client = new MsSqlClient(login, secret, address, dataBaseName);
            return new DbHandle(client, new MsSqlSelect(), new MsSqlInsert(), new MsSqlUpdate(), new MsSqlDelete());
        }
    }
}