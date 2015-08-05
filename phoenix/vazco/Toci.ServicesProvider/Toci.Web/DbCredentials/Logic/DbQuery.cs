using System;
using System.Collections.Generic;
using DbCredentials.Logic.DbModels;
using DbCredentials.Logic.QueryModels;
using DbCrypting.Logic;
using Toci.Db.ClusterAccess;

namespace DbCredentials.Logic
{
    public class DbQuery
    {
        protected Dictionary<string, Func<QueryModel>> QueryModelDictionary = new Dictionary<string, Func<QueryModel>>
        {
            {"ProjectAccess", () => new QueryProjectAccessModel()},
            {"Projects", () => new QueryProjectsModel()},
            {"Scopes", () => new QueryScopesModel()},
            {"Users", () => new QueryUsersModel()},
        };
        
        protected Dictionary<string, Func<DbModel>> DbModelDictionary = new Dictionary<string, Func<DbModel>>
        {
            {"ProjectAccess", () => new DbProjectAccessModel()},
            {"Projects", () => new DbProjectsModel()},
            {"Scopes", () => new DbScopesModel()},
            {"Users", () => new DbUsersModel()},
        };

        public void Save(DbModel model, string tableName)
        {
            
            var query = QueryModelDictionary[tableName]();
            var dbh = DbConnect.Connect();

            //model.EncryptModel(_temporarySecret);
            query.FillAddInModel(model);
            dbh.InsertData(query);


        }

        public List<DbModel> Load(string tableName)
        {

            var dbHandle = DbConnect.Connect();
            var query = QueryModelDictionary[tableName]();
            query.SetAll();

            var dbModelList = DbModelDictionary[tableName]().GetDbModelList(query, dbHandle);
            //dbModelList.DecryptDbModels(_temporarySecret);



            return (dbModelList);
        }

        //public void Update(DbModel model, string tableName)
        //{
        //    var query = QueryModelDictionary[tableName]();
        //    var dbh = DbConnect.Connect();

        //    //model.EncryptModel(_temporarySecret);

        //    query.SetData(model.data);
        //    query.SetHash(model.hash);

        //    query.AddIsWhere(TimeColumnName, model.addingTime, true);
        //    query.AddIsWhere(NickColumnName, model.nick, true);
        //    dbh.UpdateData(query);

        //}

        //public void Delete(DbModel model, string tableName)
        //{
        //    var query = QueryModelDictionary[tableName]();
        //    var dbh = DbConnect.Connect();
        //    query.AddIsWhere(IdColumnName, model.Id, true);
        //    dbh.DeleteData(query);
        //}

        
    }
}