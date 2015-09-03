using Toci.Db.DbVirtualization.SQLQuery;

using Toci.Db.Interfaces;



namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlDelete : SqlQueryWithWhereClause, IDelete
    {
        private const string Pattern = "delete from {0}";

        protected override string GetQueryWithoutWherePart(IModel model)
        {
            return string.Format(Pattern, model.GetTableName());
        }
    }
}
