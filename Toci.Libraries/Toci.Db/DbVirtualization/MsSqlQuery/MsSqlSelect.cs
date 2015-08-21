using System.Collections.Generic;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlSelect : SqlQuery, ISelect
    {
        private const string SELECT_PATTERN = "SELECT {0} FROM {1}";
        private const string SELECT_WHERE_PATTERN = "SELECT {0} FROM {1} WHERE {2}";

        protected bool Where;

        public override string GetQuery(IModel model)
        {
            string columnNames = string.Join(COLUMNS_DELIMITER, model.GetFields().Select(item => item.Key));

            var whereStatement = GetWhereStatement(model);

            if (Where)
            {
                Where = false;
                return string.Format(SELECT_WHERE_PATTERN, columnNames, model.GetTableName(), whereStatement);
            }

            return string.Format(SELECT_PATTERN, columnNames, model.GetTableName());
        }

        protected override string GetWhereStatement(IModel model)
        {
            var whereList = new List<string>();

            foreach (var item in model.GetFields())
            {
                if (item.Value.IsWhere())
                {
                    whereList.Add(string.Format(WHERE, item.Key, GetClauseSign(item.Value.GetSelectClause()), GetSurroundedValue(item.Value.GetValue())));
                    Where = true;
                }
            }

            return string.Join(AndOperator, whereList);
        }
    }
}
