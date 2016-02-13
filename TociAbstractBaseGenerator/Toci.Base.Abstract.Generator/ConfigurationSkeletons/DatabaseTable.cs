using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class DatabaseTable : IDatabaseTable
    {
        public string TableName { get; set; }
        public IDictionary<string, IDatabaseColumn> TableColumns { get; set; }

        public IDictionary<string, IBusinessLogicConfiguration> TableColumnsBusinessGenerator { get; set; }
        public IDictionary<string, IDatabaseTable> ReferencingTables { get; set; }
    }
}