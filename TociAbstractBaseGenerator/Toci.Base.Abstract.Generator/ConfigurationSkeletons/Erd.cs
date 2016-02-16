using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class Erd : IErd
    {
        public Dictionary<string, IDatabaseTableConfiguration> EntireDatabase { get; set; }

        public void AddDbTable(string tableName, IDatabaseTableConfiguration table)
        {
            throw new System.NotImplementedException();
        }
    }
}