using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IErd
    {
        Dictionary<string, IDatabaseTableConfiguration> EntireDatabase { get; set; }

        void AddDbTable(string tableName, IDatabaseTableConfiguration table);
    }
}