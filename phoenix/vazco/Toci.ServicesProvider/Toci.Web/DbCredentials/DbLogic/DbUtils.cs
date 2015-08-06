using System;
using System.Collections.Generic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.DbLogic
{
    public class DbUtils
    {
        protected const string TableName = "Projects";

        protected Dictionary<string, Func<string, bool>> primaryKeys = new Dictionary<string, Func<string, bool>>
        {
            {"Projects", columnName => columnName.ToLower().Equals("projectid")},
            {"Scopes", columnName => columnName.ToLower().Equals("scopeid")},
        };

        public void WhereClause(Model model, string columnName)
        {
            model.SetWhere(columnName.ToLower());

            if (primaryKeys[model.GetTableName()](columnName.ToLower()))
            {
                model.SetPrimaryKey(columnName.ToLower());
            }
        }

        public void ModficateDate(Model model)
        {
            if (model.GetTableName().Equals(TableName))
            {
                var newmodel = (Projects)model;
                newmodel.modificationdate = DateTime.Now;
            }
        }

        public void Encrypt(Model model)
        {
            if (model.GetTableName().Equals("Projects"))
            {
                model.EncryptModel();
            }
        }

        public List<IModel> Decrypt(List<IModel> listOfModels, string tableName)
        {
            return tableName.Equals("Projects") ? listOfModels.DecryptModels() : listOfModels;
        }
    }
}