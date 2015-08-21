using System.Collections.Generic;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization.MsSqlQuery
{
    public class MsSqlDelete : SqlQuery, IDelete
    {
        private const string PATTERN = "delete from {0} where {1};";

        public override string GetQuery(IModel model)
        {
	        var whereStatement = GetWhereStatement(model);
	       
		    return string.Format(PATTERN, model.GetTableName(), whereStatement);
        }
    }
}
