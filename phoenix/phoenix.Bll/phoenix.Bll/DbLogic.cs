using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Phoenix.Bll.Interfaces;
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
            DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("Patryk");
            //DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("Terry");

            DbHandle = GetDbHandle(accessData.UserName, accessData.Password,
                accessData.DbAdress, accessData.DbName);
        }

        public virtual IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
            // podac obiekt pracujacy z baza danych
            return DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, user, password, dbAddress, dbName);

        }

        protected List<T> FetchModelsFromDb<T>(IModel model) where T : Model
        {
            return model.GetDataRowsList(DbHandle.GetData(model)).Cast<T>().ToList();
        }

        protected T FetchModelFromDb<T>(IModel model) where T : Model
        {
            var modelFromDb = model.GetDataRowsList(DbHandle.GetData(model));
            return modelFromDb.Count == 0 ? default(T) : (T) modelFromDb[0];
        }

        protected T FetchModelById<T>(int id) where T : Model, new()
        {
            T model = new T() { Id = id };
            model.SetSelect("id", SelectClause.Equal);
            return FetchModelFromDb<T>(model);
        }

        protected List<TModel> FetchModelsByColumnValue<TModel, TValue>(string columnName, SelectClause clause, TValue value)
            where TModel : Model, new()
            where TValue : new()
        {
            TModel model = new TModel();
            model.SetSelect(columnName, clause, value);
            return FetchModelsFromDb<TModel>(model);
        }

        //TODO CreateMap przy starcie apliakcji, warstwa między business model i db logic

        protected T GetElementById<T, TModel>(int id) where TModel : Model, new()
        {
            TModel model = FetchModelById<TModel>(id);

            Mapper.CreateMap<TModel, T>();

            return Mapper.Map<T>(model);
        }

        protected T GetElementById<T, TModel>(int id, Expression<Func<T, object>> destMember, Action<IMemberConfigurationExpression<TModel>> action) 
            where TModel : Model, new() //for customized map
        {
            TModel model = FetchModelById<TModel>(id);
            
            

            return Mapper.Map<T>(model);
        }

        protected IEnumerable<T> GetAllElements<T, TModel>() where TModel : Model, new() 
        {
            var modelsList = FetchModelsFromDb<TModel>(new TModel());

            

            return modelsList.Select(model => Mapper.Map<T>(model)).ToList();
        }

        protected IEnumerable<T> GetAllElements<T, TModel>(Expression<Func<T, object>> destMember, Action<IMemberConfigurationExpression<TModel>> action) 
            where TModel : Model, new() //for customized map
        {
            var modelsList = FetchModelsFromDb<TModel>(new TModel());

            return modelsList.Select(model => Mapper.Map<T>(model)).ToList();
        }
    }
}