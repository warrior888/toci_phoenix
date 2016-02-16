using Toci.Base.Abstract.Generator.BaseTypes.Database.Virtualization.PostgreSql;

namespace Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling.Virtualization
{
    public class PostgreSqlSingleDdlParser : SingleDdlParser
    {
        public PostgreSqlSingleDdlParser()
        {
            TypesMap = new PostgreSqlVirtualStorageTypeMap();
        }
    }
}