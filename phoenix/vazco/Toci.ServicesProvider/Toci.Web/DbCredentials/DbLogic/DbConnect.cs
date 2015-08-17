using DbCredentials.Config;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace DbCredentials.DbLogic
{
    public class DbConnect
    {
        private static readonly string login;
        private static readonly string secret;
        private static readonly string address;
        private static readonly string dataBaseName;

        static DbConnect()
        {
            login = DbConfig.login;
            secret = DbConfig.secret;
            address = DbConfig.address;
            dataBaseName = DbConfig.dataBaseName;
        }

        public static DbHandle Connect()
        {
            var client = new PostgreSqlClient(login, secret, address, dataBaseName);
            return new DbHandle(client, new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete());
        } 
    }
}