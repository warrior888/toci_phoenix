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
        private const string IdColumnName = "id";
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

            var vazcoDataRows = itemModel.GetDataRowsList(dbh.GetData(itemModel));
            var vazcoEntityList = vazcoDataRows.Cast<VazcoTable>().ToList();


           
            vazcoEntityList.DecryptDbModels(_temporarySecret);
            return DbUtils.SortListByTime(vazcoEntityList);
        }

        public void Delete(VazcoTable model)
        {
            var dbh = DbConnect.Connect();
            model.SetWhere(IdColumnName);
            
            dbh.DeleteData(model);
        }
        public void Update(VazcoTable model)
        {
            var dbh = DbConnect.Connect();

            model.EncryptModel(_temporarySecret);
            model.SetWhere(IdColumnName);
            model.SetPrimaryKey(IdColumnName);

            dbh.UpdateData(model);
        }
    }
}