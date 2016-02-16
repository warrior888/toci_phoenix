using System;
using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IDatabaseColumnConfiguration
    {
        // typ kolumny
        string Kind { get; set; }

        string Name { get; set; }

        object Value { get; set; }

        IDictionary<string, IDatabaseColumnConfiguration> Constraints { get; set; }
    }
}