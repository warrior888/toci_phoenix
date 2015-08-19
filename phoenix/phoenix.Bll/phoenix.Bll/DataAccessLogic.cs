using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Toci.Db.DbVirtualization;

namespace Phoenix.Bll
{
    public abstract class DataAccessLogic : DbLogic
    {
        protected T GetElementById<T, TModel>(int id) where TModel : Model, new()
        {
            TModel model = FetchModelById<TModel>(id);
            return Mapper.Map<T>(model);
        }

        protected IEnumerable<T> GetAllElements<T, TModel>() where TModel : Model, new()
        {
            var modelsList = FetchModelsFromDb<TModel>(new TModel());
            return modelsList.Select(Mapper.Map<T>);
        }

        protected List<T> GetElementsByColumnValue<T, TModel, TValue>(string columnName, SelectClause clause, TValue value)
            where TModel : Model, new()
            where TValue : new()
        {
            var modelsList = FetchModelsByColumnValue<TModel, TValue>(columnName, clause, value);
            return modelsList.Select(Mapper.Map<T>).ToList();
        }
    }
}