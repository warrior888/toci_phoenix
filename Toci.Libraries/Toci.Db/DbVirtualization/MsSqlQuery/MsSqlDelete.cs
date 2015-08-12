using System;
using System.Collections.Generic;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlDelete : SqlQuery, IDelete
    {
        private const string PATTERN = "delete from {0} where {1};";
	    private const string equalSign = "=";
		private const string andSign = " and ";
        public override string GetQuery(IModel model)
        {
 
			var whereDelete = new List<string>();

	        foreach (var item  in model.GetFields())
	        {
		        if (item.Value.IsWhere())
		        {
			        whereDelete.Add(item.Value.GetColumnName() + equalSign + GetSurroundedValue(item.Value.GetValue()));
		        }
	        }

	        var where = String.Join(andSign, whereDelete);
	       
		    return string.Format(PATTERN, model.GetTableName(), where);
        }
    }
}
