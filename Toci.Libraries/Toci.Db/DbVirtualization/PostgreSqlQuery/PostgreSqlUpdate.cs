using System.Collections.Generic;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.PostgreSqlQuery
{
    public class PostgreSqlUpdate : SqlQuery, IUpdate
    {
        private const string Pattern = "UPDATE {0} SET {1}{2};";
        private const string AssignmentPattern = "{0} = {1}";
        private const string Comma = ", ";
        private const int MinStatementLength = 2;

        public override string GetQuery(IModel model)
        {
            var where = GetWhereStatement(model);
            return (where.Length < MinStatementLength) ? string.Empty :
                                                         string.Format(Pattern, model.GetTableName(), GetSetStatement(model), where);
        }

        private string GetSetStatement(IModel model)
        {
            //TODO sprawdzic poprawnosc LINQ
           /* var list = model.GetFields().Where(item => item.Value.GetValue() != null && !item.Value.IsPrimaryKey()).ToList();
            return string.Join(Comma, list.Select(item => string.Format(AssignmentPattern, item.Key, GetSurroundedValue(item.Value.GetValue()))));*/
            var list = (from item in model.GetFields() where item.Value.GetValue() != null && !item.Value.IsPrimaryKey() select string.Format(AssignmentPattern, item.Key, GetSurroundedValue(item.Value.GetValue()))).ToList();
            return string.Join(Comma, list);
        }
    }
}
