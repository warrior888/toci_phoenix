using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.PostgreSqlQuery
{
    public class PostgreSqlSelect : SqlQuery, ISelect
    {
        private const string SELECT_PATTERN = "SELECT {0} FROM {1}";
        private const string WHERE_PATTERN = "SELECT {0} FROM {1} WHERE {2}";
        private const string WHERE = "{0} {1} {2}";
        private const string AND = " AND ";
        private bool where;

        public override string GetQuery(IModel model)
        {
            //string columnNames = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => item.Key));
            string columnNames = "*";

            var whereList = new List<string>();

            foreach (var item in model.GetFields())
            {
                if (item.Value.IsWhere())
                {                                                           
                    whereList.Add(string.Format(WHERE, item.Key, GetClauseSign(item.Value.GetSelectClause()), GetSurroundedValue(item.Value.GetValue())));
                    where = true;
                }
            }

            var whereResult = string.Join(AND, whereList);

            if (where)
            {
                return string.Format(WHERE_PATTERN, columnNames, model.GetTableName(), whereResult);
            }
            string query =  string.Format(SELECT_PATTERN, columnNames, model.GetTableName());
            return query;
        }

    }
}
