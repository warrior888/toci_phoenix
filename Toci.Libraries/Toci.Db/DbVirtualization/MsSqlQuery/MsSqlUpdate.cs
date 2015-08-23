using System.Linq;
using Toci.Db.DbVirtualization.SQLQuery;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlUpdate : SqlQueryWithNecessaryWhereClause, IUpdate
    {
        private const string Pattern = "UPDATE {0} SET {1}";
        private const string AssignmentPattern = "{0} = {1}";
        private const string Comma = ", ";

        protected override string GetQueryWithoutWherePart(IModel model)
        {
            return string.Format(Pattern, model.GetTableName(), GetSetStatement(model));
        }

        protected virtual string GetSetStatement(IModel model)
        {
            var list = model.GetFields().Where(x =>!IsObjectDefault(x.Value.GetValue()) && !x.Value.IsPrimaryKey()).
                Select(item => string.Format(AssignmentPattern, item.Key, GetSurroundedValue(item.Value.GetValue()))).
                Cast<object>().ToList();
            return string.Join(Comma, list);
        }

        private bool IsObjectDefault<T>(T obj)
        {
            return obj==null;
        }
    }
}
