using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class BusinessLogicConfiguration :  IBusinessLogicConfiguration
    {
        public ILogicConfiguration Configuration { get; set; }
        public IDictionary<string, IDatabaseTableConfiguration> Tables { get; set; }
        public IDictionary<string, IBusinessLogic> DependentBusinessLogics { get; set; }
    }

}