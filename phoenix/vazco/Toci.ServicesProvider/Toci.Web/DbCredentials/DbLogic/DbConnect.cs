using DbCredentials.Config;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.MsSqlQuery;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace DbCredentials.DbLogic
{
    public class DbConnect
    {
        private readonly string login;
        private readonly string secret;
        private readonly string address;
        private readonly string dataBaseName;

        public DbConnect(DbConfig dbConfig)
        {
            login = dbConfig.login;
            secret = dbConfig.secret;
            address = dbConfig.address;
            dataBaseName = dbConfig.dataBaseName;
        }

        public  DbHandle Connect()
        {
            var client = new PostgreSqlClient(login, secret, address, dataBaseName);
            return new DbHandle(client, new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete());
        } 
    }
}