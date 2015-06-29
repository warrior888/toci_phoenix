using System.Collections.Generic;

namespace Toci.Utilities.Interfaces.Generator.DatabaseModelGenerator.DbDdlParser
{
    public interface IDdlParser
    {
        Dictionary<string, IDbFieldEntryEntity> GetFieldEntryEntities(string ddl, string separator, out string tableName); // create ta (dfsafgds, fdsagfads, fdgs);
    }
}
