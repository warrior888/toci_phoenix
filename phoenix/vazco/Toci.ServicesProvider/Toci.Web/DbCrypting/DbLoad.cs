using System.Collections.Generic;
using DbCrypting.Config;
using DbCrypting.Logic;
using Toci.Db.ClusterAccess;

namespace DbCrypting
{
    public class DbLoad
    {
        private readonly string _tableName;
        private readonly string _temporarySecret;

        public DbLoad()
        {
            _tableName = LoadConfig.TableName;
            _temporarySecret = LoadConfig.TemporarySecret;
        }

        public List<DbModel> Load()
        {

            var dbh = DbConnect.Connect();
            var itemModel = new QueryModel(_tableName);
            itemModel.SetGwiazdka();
            var modelListGenerator = new GenerateDbModelList<QueryModel, DbHandle>();


            var DbModelList = modelListGenerator.GetDbModelList(itemModel, dbh);
            DbModelList.DecryptDbModels(_temporarySecret);



            return DbUtils.SortListByTime(DbModelList);
        }
    }
}