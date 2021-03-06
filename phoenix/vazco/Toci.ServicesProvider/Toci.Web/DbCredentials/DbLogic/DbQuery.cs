﻿using System;
using System.Collections.Generic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic
{
    public class DbQuery
    {
        private DbHandle dbHandle;
        private DbUtils dbUtils;


        public DbQuery()
        {
            dbHandle = DbConnect.Connect();
            dbUtils = new DbUtils();
        }


        public int Save(Model model)
        {
            dbUtils.ModficateDate(model);
            dbUtils.Encrypt(model);
            return dbHandle.InsertData(model);
        }

        public List<IModel> Load(Model model)
        {
      
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