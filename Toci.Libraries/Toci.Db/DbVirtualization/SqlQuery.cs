using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization
{
    public abstract class SqlQuery : IQuery
    {
        protected const string COLUMNS_DELIMITER = ",";
        
        protected const string WHERE = "{0} {1} {2}";
        protected const string AndOperator = " AND ";

        protected Dictionary<Type, string> Surroundings = new Dictionary<Type, string>()
        {
            {typeof(int), ""},
            {typeof(string), "'"},
            {typeof(double), ""},
            {typeof(DateTime), "'"}
        };

        protected Dictionary<SelectClause, string> Signs = new Dictionary<SelectClause, string>()
        {
            {SelectClause.Equal, "="},
            {SelectClause.NotEqual, "!="}, 
            {SelectClause.Like, "LIKE"}    
        };

        public abstract string GetQuery(IModel model);

        protected string GetSurroundedValue<T>(T value)
        {
            // beatka 'beatka' 5 5
            return string.Format("{0}{1}{0}", Surroundings.ContainsKey(value.GetType()) ? Surroundings[value.GetType()] : "'", value);
        }

        protected string GetClauseSign(SelectClause clause)
        {
            return string.Format("{0}", Signs[(clause)]);
        }

        protected virtual string GetWhereStatement(IModel model)
        {
            var whereList = new List<string>();
            model.GetFields().Where(item => item.Value.IsWhere()).ToList().ForEach(
                item => whereList.Add(string.Format(WHERE, item.Key, GetClauseSign(item.Value.GetSelectClause()), GetSurroundedValue(item.Value.GetValue())))
            );
            return whereList.Any()
                ? string.Format(" WHERE {0}", string.Join(AndOperator, whereList))
                : string.Join(AndOperator, whereList);
        }
    }
}
