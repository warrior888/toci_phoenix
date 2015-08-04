using System;
using System.Collections.Generic;
using DbCredentials.CredentialsModels;
using DbCrypting.Logic;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic
{
    public class DbQuery
    {
        private DbHandle dbHandle;

        public DbQuery()
        {
            dbHandle = DbConnect.Connect();
        }


        public int Save(Model model)
        {
            return dbHandle.InsertData(model);
        }

        public List<IModel> Load(Model model)
        {
            var dataSet = dbHandle.GetData(model);
            return model.GetDataRowsList(dataSet);
        }

        public int Update(Model model)
        {
            return dbHandle.UpdateData(model);
        }

        public int Delete(Model model)
        {
            return dbHandle.DeleteData(model);
        }
        
    }
}