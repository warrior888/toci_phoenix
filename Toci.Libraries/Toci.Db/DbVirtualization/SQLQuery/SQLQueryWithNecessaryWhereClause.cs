using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.SQLQuery
{
    public abstract class SqlQueryWithNecessaryWhereClause : SqlQueryWithWhereClause
    {
        public override string GetQuery(IModel model)
        {
            var whereStatement = GetWhereStatement(model);
            return whereStatement.Any()
                ? string.Format(QueryWithWherePattern, GetQueryWithoutWherePart(model), whereStatement)
                : string.Empty;
        }
    }
}