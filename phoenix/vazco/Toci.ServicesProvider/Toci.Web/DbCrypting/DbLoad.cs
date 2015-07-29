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
            var ModelListGenerator = new GenerateDbModelList<AddInModel, DbHandle>();


            var DbModelList = ModelListGenerator.GetDbModelList(itemModel, dbh);
            DbModelList.DDecryptDbModels();



            return DbUtils.SortListByTime(DbModelList);
        }
    }
}