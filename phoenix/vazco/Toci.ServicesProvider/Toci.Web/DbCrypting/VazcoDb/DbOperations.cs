using System;
using System.Collections.Generic;
using System.Linq;
using DbCrypting.Config;
using DbCrypting.Logic;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;

namespace DbCrypting
{
    public class DbOperations
    {
        private readonly string _tableName;
        private readonly string _temporarySecret;

        public DbOperations()
        {
            _tableName = LoadConfig.TableName;
            _temporarySecret = LoadConfig.TemporarySecret;
        }


        public void Save(VazcoTable model)
        {
            var dbh = DbConnect.Connect();

            model.EncryptModel(_temporarySecret);
            model.FillAddInModel();
            dbh.InsertData(model);
        }

        public List<VazcoTable> Load()
        {

            var dbh = DbConnect.Connect();
            var itemModel = new VazcoTable
            {
                id = 0,
                data = null,
                name = null,
                addingTime = default(DateTime),
                hash = null
            };
            var res = dbh.GetData(itemModel);
            var res2 = itemModel.GetDataRowsList(res);
            var vazcoEntityList = res2.Cast<VazcoTable>().ToList();


           
            vazcoEntityList.DecryptDbModels(_temporarySecret);



            return DbUtils.SortListByTime(vazcoEntityList);
        }

    }
}