using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Phoenix.Bll.Interfaces;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Bll
{
    public abstract class DbLogic : IDbLogic
    {
        protected IDbHandle DbHandle;
        protected DbHandleAccessDataFactory AccessDataFactory;

        protected DbLogic()
        {
            //DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("Patryk");
            DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("Terry");

            DbHandle = GetDbHandle(accessData.UserName, accessData.Password,
                                   accessData.DbAdress, accessData.DbName);
        }

        public virtual IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
            // podac obiekt pracujacy z baza danych
            return DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, user, password, dbAddress, dbName);

        }

        protected List<T> ConvertDataSetToModels<T>(IModel model)
        {
            return model.GetDataRowsList(DbHandle.GetData(model)).Cast<T>().ToList();
        }

        protected TModel GetOneRowById<TModel>(string columnName, SelectClause clause, int id) where TModel : Model, new()
        {
            TModel model = new TModel() {Id = id};
            model.SetSelect(columnName, clause);

            var resultsList = ConvertDataSetToModels<TModel>(model);

            return resultsList.Count == 0 ? null : resultsList[0];
        }
    }
}