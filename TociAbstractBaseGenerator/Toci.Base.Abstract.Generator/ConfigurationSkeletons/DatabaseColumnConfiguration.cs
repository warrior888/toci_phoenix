using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class DatabaseColumnConfiguration : IDatabaseColumnConfiguration
    {
        public string Kind { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public IDictionary<string, IDatabaseColumnConfiguration> Constraints { get; set; }
    }
}