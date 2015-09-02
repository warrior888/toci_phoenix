using System.Data;
using Npgsql;

namespace Toci.Db.Clients
{
    public class PostgreSqlClient : SqlClientBase
    {
        protected NpgsqlConnection Connection;
        private const string connectionPattern = "Server={0};Port=5432;Database={1};User Id={2};Password={3};";
        private string connectionString;

        public PostgreSqlClient(string name, string password, string dbAddress, string dbName) : base(name, password, dbAddress, dbName)
        {
            connectionString = string.Format(connectionPattern, DbAddress, DbName, UserName, Password);
        }

        public override DataSet GetData(string query)
        { 
            using (Connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, Connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                var result = new DataSet();
                adapter.Fill(result);

                return result;
            }
        }

        public override int SetData(string query)
        {
            using (Connection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, Connection);
                Connection.Open();
                return command.ExecuteNonQuery();
            }
        }
    }
}
