using DbCrypting.Config;
using DbCrypting.Logic;

namespace DbCrypting
{
    public class DbSave
    {
        private readonly string _tableName;
        private readonly string _temporarySecret;
        private const string IdColumnName = "id";

        public DbSave()
        {
            _tableName = LoadConfig.TableName;
            _temporarySecret = LoadConfig.TemporarySecret;
        }

        public void Save(DbModel model)
        {
            var query = new QueryModel(_tableName);
            var dbh = DbConnect.Connect();


            model.EncryptModel(_temporarySecret);
            query.FillAddInModel(model);
            dbh.InsertData(query);


        }

        public void Update(DbModel model)
        {
            var query = new QueryModel(_tableName);
            var dbh = DbConnect.Connect();
            model.EncryptModel(_temporarySecret);
            query.FillAddInModel(model);
            query.AddIsWhere(IdColumnName,model.id,true);
            dbh.UpdateData(query);

        }

        public void Delete(DbModel model)
        {
            var query = new QueryModel(_tableName);
            var dbh = DbConnect.Connect();
            query.AddIsWhere(IdColumnName, model.id, true);
            dbh.DeleteData(query);
        }

    }
}