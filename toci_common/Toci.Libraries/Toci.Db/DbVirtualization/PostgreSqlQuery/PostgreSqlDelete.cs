using Toci.Db.DbVirtualization.SQLQuery;
﻿using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.PostgreSqlQuery
{
	public class PostgreSqlDelete : SqlQueryWithWhereClause, IDelete
	{
		private const string Pattern = "DELETE FROM {0}";

	    protected override string GetQueryWithoutWherePart(IModel model)
	    {
            return string.Format(Pattern, model.GetTableName());
	    }
	}
}
