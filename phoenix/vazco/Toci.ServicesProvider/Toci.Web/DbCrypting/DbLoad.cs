﻿using System.Collections.Generic;
using DbCrypting.Config;
using DbCrypting.Logic;
using Toci.Db.ClusterAccess;

namespace DbCrypting
{
    public class DbLoad
    {
        private readonly string _temporarySecret;

        public DbLoad()
        {
            _temporarySecret = LoadConfig.TemporarySecret;
        }

        public List<DbModel> Load()
        {

            var dbh = DbConnect.Connect();
            var itemModel = new QueryModel();
            itemModel.SetAll();
            var modelListGenerator = new GenerateDbModelList<QueryModel, DbHandle>();


            var dbModelList = modelListGenerator.GetDbModelList(itemModel, dbh);
            dbModelList.DecryptDbModels(_temporarySecret);



            return DbUtils.SortListByTime(dbModelList);
        }
    }
}