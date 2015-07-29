using System.Collections.Generic;
using DBAccessResourceServer.Logic;
using Toci.Db.ClusterAccess;

namespace DBAccessResourceServer.Models
{
    public class DbLoad
    {
        private const string TableName = "LolTable";

        public List<DbModel> Load()
        {

            var dbh = DbConnect.Connect();
            var itemModel = new AddInModel(TableName);
            itemModel.SetGwiazdka();
            var modelListGenerator = new GenerateDbModelList<AddInModel, DbHandle>();


            var DbModelList = modelListGenerator.GetDbModelList(itemModel, dbh);
            DbModelList.DDecryptDbModels();



            return DbUtils.SortListByTime(DbModelList);
        }
    }
}