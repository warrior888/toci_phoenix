using System.Data;
using System.Data.SqlClient;

namespace Toci.Db.Clients
{
    public class MsSqlClient : SqlClientBase
    {
        protected SqlConnection Connection;
        private const string connectionPattern = "user id={0};password={1};server={2};Trusted_Connection=yes;database={3};connection timeout=30";

        private string connectionString;
        public MsSqlClient(string name, string password, string dbAddress, string dbName) : base(name, password, dbAddress, dbName)
        {
            this.connectionString = string.Format(connectionPattern, this.UserName, this.Password, this.DbAddress, this.DbName);
        }

        public override DataSet GetData(string query)
        {
            using (this.Connection = new SqlConnection(this.connectionString))
            {
                var adapter = new SqlDataAdapter(new SqlCommand(query, this.Connection));
                var result = new DataSet();

                adapter.Fill(result);

                return result;
            }
        }

        public override int SetData(string query)
        {
            using (this.Connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(query, this.Connection);
                this.Connection.Open();

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
