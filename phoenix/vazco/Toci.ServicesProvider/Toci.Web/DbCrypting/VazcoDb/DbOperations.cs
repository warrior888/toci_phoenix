using System;
using System.Collections.Generic;
using System.Linq;
using DbCrypting.Config;
using DbCrypting.Logic;
using Toci.Db.ClusterAccess;
using Toci.ErrorsAndMessages.Exceptions;
using Toci.Utilities.Common.Exceptions;

namespace DbCrypting.VazcoDb
{
    public class DbOperations
    {
        private const string IdColumnName = VazcoTable.ID;
        
        private readonly string _temporarySecret;

        private DbConnect connector;
        private DbHandle dbh;

        public DbOperations(string password,DbConfig config)
        {

            _temporarySecret = password;
            connector = new DbConnect(config);
            dbh = connector.Connect();

        }


        public void Save(VazcoTable model)
        {

            model.EncryptModel(_temporarySecret);
            model.FillAddInModel();
            dbh.InsertData(model);
        }

        public List<VazcoTable> Load()
        {

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
            model.SetWhere(IdColumnName);
            try
            {
                dbh.DeleteData(model);
            }
            catch (Exception)
            {
              throw new WebApiTociApplicationException("The given ID is not present in the database.", "zle id", (int)ApiErrors.WrongId);
            }
        }
        public void Update(VazcoTable model)
        {

            if (model.data!= default(string))
            {
             model.EncryptModel(_temporarySecret);

            }
            model.SetWhere(IdColumnName);
            model.SetPrimaryKey(IdColumnName);
            model.addingTime = DateTime.Now;
            try
            {
                dbh.UpdateData(model);
            }
            catch(Exception)
            {
                throw new WebApiTociApplicationException("The given ID is not present in the database.", "zle id", (int)ApiErrors.WrongId);
            }
            
        }
    }
}