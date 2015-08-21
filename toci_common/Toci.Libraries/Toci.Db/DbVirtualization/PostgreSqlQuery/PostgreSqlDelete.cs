using System.Collections.Generic;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.PostgreSqlQuery
{
	public class PostgreSqlDelete : SqlQuery, IDelete
	{
		private const string PATTERN = "delete from {0}{1};";

		public override string GetQuery(IModel model)
		{
            return string.Format(PATTERN, model.GetTableName(), GetWhereStatement(model));
		}
    }
}
