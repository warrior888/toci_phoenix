using DBAccessResourceServer.Logic;

namespace DBAccessResourceServer.Models
{
    public class DbSave
    {
        private const string LogTableName = "LolTable";
        public void Save(DbModel model)
        {
            var LogModel = new AddInModel(LogTableName);
            var dbh = DbConnect.Connect();


            model.EncryptModel();
            LogModel.FillAddInModel(model);
            dbh.InsertData(LogModel);


        }
    }
}