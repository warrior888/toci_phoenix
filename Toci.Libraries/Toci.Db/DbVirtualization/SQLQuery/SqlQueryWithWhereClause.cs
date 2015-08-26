using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.SQLQuery
{
    public abstract class SqlQueryWithWhereClause : SqlQuery
    {
        protected const string Where = "{0} {1} {2}";
        protected const string AndOperator = " AND ";
        protected const string QueryWithWherePattern = "{0}{1};";

        public override string GetQuery(IModel model)
        {
            return string.Format(QueryWithWherePattern, GetQueryWithoutWherePart(model), GetWhereStatement(model));
        } 

        protected abstract string GetQueryWithoutWherePart(IModel model); 

        protected virtual string GetWhereStatement(IModel model)
        {
            var whereList = new List<string>();
            model.GetFields().Where(item => item.Value.IsWhere()).ToList().ForEach(
                item => whereList.Add(string.Format(Where, item.Key, GetClauseSign(item.Value.GetSelectClause()), GetSurroundedValue(item.Value.ValueForWhereClause)))
            );
            return whereList.Any()
                ? string.Format(" WHERE {0}", string.Join(AndOperator, whereList))
                : string.Empty;
        }
    }
}