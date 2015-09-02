using System.Collections.Generic;
using System.Linq;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Db.DbUtils
{
    public abstract class DbLogic : IDbLogic
    {
        protected IDbHandle DbHandle;
        private const string Id = "id"; 

        protected DbLogic()
        {
            // tutaj dane do polaczenia z baza powinny byc argumentami konstruktora ale na razie niech tak bedzie ;)
            DbHandle = GetDbHandle("","","","");
        }

        public virtual IDbHandle GetDbHandle(string user, string password, string dbAddress, string dbName)
        {
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
            T model = new T();
            model.SetSelect(Id, SelectClause.Equal, id);
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
    }
}