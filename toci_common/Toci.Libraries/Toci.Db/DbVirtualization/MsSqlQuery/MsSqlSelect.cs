using Toci.Db.DbVirtualization.SQLQuery;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlSelect : SqlQueryWithPossibleWhereClause, ISelect
    {
        private const string SelectPattern = "SELECT {0} FROM {1}";

        protected override string GetQueryWithoutWherePart(IModel model)
        {
            //string columnNames = string.Join(ColumnsDelimiter, model.GetFields().Select(item => item.Key));
            string columnNames = "*";
            return string.Format(SelectPattern, columnNames, model.GetTableName());
        }
    }
}
