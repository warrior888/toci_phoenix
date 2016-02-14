using System.Collections;
using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IDatabaseTableConfiguration
    {
        string TableName { get; set; }

        IDictionary<string, IDatabaseColumnConfiguration> TableColumns { get; set; }

        IDictionary<string, IDatabaseTableConfiguration> ReferencingTables { get; set; }
    }
}