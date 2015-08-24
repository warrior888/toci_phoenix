using DbCrypting.Config;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.PostgreSqlQuery;

namespace DbCrypting.Logic
{
     class DbConnect
    {
        private readonly string login;
        private readonly string secret;
        private readonly string address;
        private readonly string dataBaseName;

        public DbConnect(DbConfig config)
        {
            login = config.login;
            secret = config.secret;
            address = config.address;
            dataBaseName = config.DataBaseName;
        }

        public  DbHandle Connect()
        {
            //var client = new MsSqlClient(login, secret, address, dataBaseName);
            var client = new PostgreSqlClient(login,secret,address,dataBaseName);
            return new DbHandle(client, new PostgreSqlSelect(), new PostgreSqlInsert(), new PostgreSqlUpdate(), new PostgreSqlDelete());
        }
    }
}