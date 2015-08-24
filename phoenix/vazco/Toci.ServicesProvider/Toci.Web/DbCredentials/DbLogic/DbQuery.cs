using System;
using System.Collections.Generic;
using DbCredentials.Config;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;
using Toci.ErrorsAndMessages.Exceptions;

namespace DbCredentials.DbLogic
{
    public class DbQuery
    {
        private DbHandle dbHandle;
        private DbUtils dbUtils;

        public DbQuery(DbConfig dbConfig)
        {
            DbConnect connect = new DbConnect(dbConfig);
            dbHandle = connect.Connect();
            dbUtils = new DbUtils();
        }


        public int Save(Model model)
        {
            var newModel = dbUtils.GetNewModel(model);
            dbUtils.ModficateDate(newModel);
            dbUtils.Encrypt(newModel);
            try
            {
                return dbHandle.InsertData(newModel);
            }
            catch (Exception)
            {
                throw new WebApiTociApplicationException("Cannot insert project.", null, (int)ApiErrors.WrongData);
            }
        }

        public List<IModel> Load(Model model)
        {
            dbUtils.SetDefaultValue(model);
            var dataSet = dbHandle.GetData(model);
            var listOfModels = model.GetDataRowsList(dataSet);

            return dbUtils.Decrypt(listOfModels, model.GetTableName());
        }
        
        public List<IModel> Load(Model model, string columnName)
        {
            
            dbUtils.WhereClause(model, columnName);
            return Load(model);
        }

        public int Update(Model model, string columnName)
        {
            dbUtils.WhereClause(model, columnName);
            dbUtils.ModficateDate(model);
            dbUtils.Encrypt(model);
            return dbHandle.UpdateData(model);
            
            
        }

        public int Delete(Model model,string columnName)
        {
            model.SetWhere(columnName.ToLower());
            return dbHandle.DeleteData(model);
        }

        
    }
}