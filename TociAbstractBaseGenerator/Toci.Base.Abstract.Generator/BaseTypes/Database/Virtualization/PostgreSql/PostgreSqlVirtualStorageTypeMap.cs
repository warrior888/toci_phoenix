using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.BaseTypes.Database.Virtualization.PostgreSql
{
    public class PostgreSqlVirtualStorageTypeMap : VirtualStorageTypeMapBase
    {
        public PostgreSqlVirtualStorageTypeMap()
        {
            TypesMap = new Dictionary<string, string>
            {
                { "character varying", "string" },
                { "int", "int" },
                { "serial", "int" },
                { "integer", "int" }, // TODO
            };
        }
    }
}