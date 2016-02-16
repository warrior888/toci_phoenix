using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Toci.Base.Abstract.Generator.Interfaces.BaseTypes.Database.Virtualization;

namespace Toci.Base.Abstract.Generator.BaseTypes.Database.Virtualization
{
    public abstract class VirtualStorageTypeMapBase : IVirtualStorageTypeMap
    {
        public Dictionary<string, string> TypesMap { get; set; }

        public string GetTypeForDbType(string dbType)
        {
           return TypesMap.ContainsKey(dbType) ? TypesMap[dbType] : null; // null?
        }

        public string GetTypeForDdlRow(string row)
        {
            return TypesMap.Where(type => row.Contains(type.Key)).Select(type => type.Value).FirstOrDefault();
        }
    }
}