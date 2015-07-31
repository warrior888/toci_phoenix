using DbCrypting.Config;
using DbCrypting.Logic;

namespace DbCrypting
{
    public class DbSave
    {
        private readonly string _tableName;
        private readonly string _temporarySecret;

        public DbSave()
        {
            _tableName = LoadConfig.TableName;
            _temporarySecret = LoadConfig.TemporarySecret;
        }

        public void Save(DbModel model)
        {
            var LogModel = new QueryModel(_tableName);
            var dbh = DbConnect.Connect();


            model.EncryptModel(_temporarySecret);
            LogModel.FillAddInModel(model);
            dbh.InsertData(LogModel);


        }
    }
}