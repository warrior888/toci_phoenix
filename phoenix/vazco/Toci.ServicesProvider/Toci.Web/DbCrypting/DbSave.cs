using DbCrypting.Config;
using DbCrypting.Logic;

namespace DbCrypting
{
    public class DbSave
    {
        private readonly string _temporarySecret;
        private const string TimeColumnName = "addingTime";
        private const string NickColumnName = "name";
        private const string IdColumnName = "id";

        public DbSave()
        {
            _temporarySecret = LoadConfig.TemporarySecret;
        }

        public void Save(DbModel model)
        {
            var query = new QueryModel();
            var dbh = DbConnect.Connect();


            model.EncryptModel(_temporarySecret);
            ///////query.FillAddInModel(model);
            dbh.InsertData(query);


        }

        public void Update(DbModel model)
        {
            var query = new QueryModel();
            var dbh = DbConnect.Connect();

            model.EncryptModel(_temporarySecret);
            
            query.SetData(model.data);
            query.SetHash(model.hash);

            query.AddIsWhere(TimeColumnName, model.addingTime, true);
            query.AddIsWhere(NickColumnName, model.nick, true);
            dbh.UpdateData(query);

        }

        public void Delete(DbModel model)
        {
            var query = new QueryModel();
            var dbh = DbConnect.Connect();
            query.AddIsWhere(IdColumnName, model.id, true);
            dbh.DeleteData(query);
        }

    }
}