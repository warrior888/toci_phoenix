using System;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.PostgreSqlQuery
{
    public class PostgreSqlInsert : SqlQuery, IInsert
    {
        private const string PATTERN = "insert into {0} ({1}) values ({2});";

        public override string GetQuery(IModel model)
        {
            string columnNames = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => item.Key));
            string columnValues = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => GetSurroundedValue(item.Value.GetValue())));
            // 'beatka',5

            return string.Format(PATTERN, model.GetTableName(), columnNames, columnValues);
        }
    }
}
