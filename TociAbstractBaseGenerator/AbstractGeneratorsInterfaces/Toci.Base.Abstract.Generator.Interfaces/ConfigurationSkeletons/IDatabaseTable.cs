using System.Collections;
using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IDatabaseTable
    {
        string TableName { get; set; }

        IDictionary<string, IDatabaseColumn> TableColumns { get; set; }

        //IDictionary<string, IBusinessLogicConfiguration> TableColumnsBusinessGenerator { get; set; }

        IDictionary<string, IDatabaseTable> ReferencingTables { get; set; }
    }
}