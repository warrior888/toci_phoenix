using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.PostgreSqlQuery
{
    public class PostgreSqlSelect : SqlQuery, ISelect
    {
        private const string SELECT_PATTERN = "SELECT {0} FROM {1}{2}";

        public override string GetQuery(IModel model)
        {
                //string columnNames = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => item.Key));
            string columnNames = "*";
            return string.Format(SELECT_PATTERN, columnNames, model.GetTableName(), GetWhereStatement(model));
        }
    }
}
