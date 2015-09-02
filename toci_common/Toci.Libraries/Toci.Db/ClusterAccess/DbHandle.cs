using System.Data;
using Toci.Db.Interfaces;

namespace Toci.Db.ClusterAccess
{
    public class DbHandle : IDbHandle
    {
        protected IDbClient client;
        protected IQuery select;
        protected IQuery insert;
        protected IQuery update;
        protected IQuery delete;

        public DbHandle(IDbClient client, ISelect select, IInsert insert, IUpdate update, IDelete delete)
        {
            this.client = client;
            this.select = select;
            this.update = update;
            this.delete = delete;
            this.insert = insert;
        }
        public DataSet GetData(IModel model)
        {
            return client.GetData(select.GetQuery(model));
        }

        public int InsertData(IModel model)
        {
            return client.SetData(insert.GetQuery(model));
        }

        public int UpdateData(IModel model)
        {
            return client.SetData(update.GetQuery(model));
        }

        public int DeleteData(IModel model)
        {
            return client.SetData(delete.GetQuery(model));
        }
    }
}
