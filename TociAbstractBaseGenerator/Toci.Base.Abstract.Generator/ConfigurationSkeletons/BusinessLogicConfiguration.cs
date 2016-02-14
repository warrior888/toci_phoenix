using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class BusinessLogicConfiguration :  IBusinessLogicConfiguration
    {
        public string Kind { get; set; }
        public object Value { get; set; }
        public IDictionary<string, IDatabaseColumnConfiguration> Constraints { get; set; }
    }

}