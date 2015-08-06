using System;
using System.Collections.Generic;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic
{
    public class DbQuery
    {
        private DbHandle dbHandle;
        private const string IdColumnName = "projectid";

        protected Dictionary<string,Func<string, bool>> primaryKeys = new Dictionary<string, Func<string, bool>>
        {
            {"Projects", columnName => columnName.ToLower().Equals("projectid")},
            {"Scopes", columnName => columnName.ToLower().Equals("scopeid")},
        };


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
            model.SetWhere(columnName.ToLower());
            
            if (primaryKeys[model.GetTableName()](columnName))
            {
                model.SetPrimaryKey(columnName.ToLower());
            }

            return Load(model);
        }

        public int Update(Model model, string columnName)
        {
            model.SetWhere(columnName.ToLower());

            if (primaryKeys[model.GetTableName()](columnName))
            {
                model.SetPrimaryKey(columnName.ToLower());
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
            else
            {
                return listOfModels;
            }
            
        }
    }
}