using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.Interfaces;

namespace Toci.Db.Clients
{
    public abstract class SqlClientBase : IDbClient
    {
        protected string UserName;
        protected string Password;
        protected string DbName;
        protected string DbAddress;

        protected SqlClientBase(string name, string password, string dbAddress, string dbName)
        {
            UserName = name;
            Password = password;
            DbAddress = dbAddress;
            DbName = dbName;
        }

        public abstract DataSet GetData(string query);

        public abstract int SetData(string query);
    }
}
