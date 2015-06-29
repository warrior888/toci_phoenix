using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlInsert : SqlQuery, IInsert
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
