using System;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IDatabaseColumn
    {
        // typ kolumny
        string Kind { get; set; }

        object Value { get; set; }

        string Constraints { get; set; }
    }
}