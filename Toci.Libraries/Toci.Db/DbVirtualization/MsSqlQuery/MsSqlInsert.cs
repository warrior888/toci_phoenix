using System.Linq;
using Toci.Db.DbVirtualization.SQLQuery;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlInsert : SqlQuery, IInsert
    {
        private const string Pattern = "insert into {0} ({1}) values ({2});";

        public override string GetQuery(IModel model)
        {
            string columnNames = string.Join(ColumnsDelimiter, model.GetFields().Select(item => item.Key));
            string columnValues = string.Join(ColumnsDelimiter, model.GetFields().Select(item => GetSurroundedValue(item.Value.GetValue())));
            // 'beatka',5

            return string.Format(Pattern, model.GetTableName(), columnNames, columnValues);
        }
    }
}
