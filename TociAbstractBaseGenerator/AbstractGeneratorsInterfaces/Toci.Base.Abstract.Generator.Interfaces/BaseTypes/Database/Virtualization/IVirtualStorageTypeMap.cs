using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.BaseTypes.Database.Virtualization
{
    public interface IVirtualStorageTypeMap
    {
        Dictionary<string, string> TypesMap { get; set; }

        string GetTypeForDbType(string dbType);

        /// <summary>
        /// For string name character varying (67)   -> string
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        string GetTypeForDdlRow(string row);
    }
}