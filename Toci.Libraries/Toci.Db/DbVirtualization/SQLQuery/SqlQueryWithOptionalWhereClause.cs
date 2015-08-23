using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.SQLQuery
{
    public abstract class SqlQueryWithPossibleWhereClause : SqlQueryWithWhereClause
    {
        public override string GetQuery(IModel model)
        {
            return string.Format(QueryWithWherePattern, GetQueryWithoutWherePart(model), GetWhereStatement(model));
        }  
    }
}