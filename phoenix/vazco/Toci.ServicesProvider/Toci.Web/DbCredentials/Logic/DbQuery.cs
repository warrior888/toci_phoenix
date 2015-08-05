using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.CredentialsModels;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic
{
    public class DbQuery
    {
        private DbHandle dbHandle;
        private const string IdColumnName = "id";
        public DbQuery()
        {
            dbHandle = DbConnect.Connect();
        }


        public int Save(Model model)
        {
            Encrypt(model);
            return dbHandle.InsertData(model);
        }

        public List<IModel> Load(Model model)
        {
      
            var dataSet = dbHandle.GetData(model);
            var listOfModels = model.GetDataRowsList(dataSet);

            return Decrypt(listOfModels, model.GetTableName());
        }
        
        public List<IModel> Load(Model model, string columnName)
        {
            model.SetWhere(columnName);
            
            if (columnName.Contains(IdColumnName))
            {
                model.SetPrimaryKey(columnName);
            }

            return Load(model);
        }

        public int Update(Model model, string columnName)
        {
            model.SetWhere(columnName);

            if (columnName.Contains(IdColumnName))
            {
                model.SetPrimaryKey(columnName);
            }
            Encrypt(model);
            return dbHandle.UpdateData(model);
        }

        public int Delete(Model model,string columnName)
        {
            model.SetWhere(columnName);
            return dbHandle.DeleteData(model);
        }

        private void Encrypt(Model model)
        {
            if (model.GetTableName().Equals("Projects"))
            {
                model.EncryptModel();
            }
        }

        private List<IModel> Decrypt(List<IModel> listOfModels, string tableName)
        {
            if (tableName.Equals("Projects"))
            {
                return listOfModels.DecryptModels();
            }
            return listOfModels;
        }
    }
}