using System.Collections.Generic;
using System.IO.Ports;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IBusinessLogicConfiguration
    {
        // typ kolumny
        string Kind { get; set; }

        object Value { get; set; }

        IDictionary<string, IDatabaseColumnConfiguration> Constraints { get; set; }
    }

}