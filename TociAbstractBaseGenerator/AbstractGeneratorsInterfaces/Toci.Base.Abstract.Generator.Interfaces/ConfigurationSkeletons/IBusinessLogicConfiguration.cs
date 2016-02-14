using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBusinessLogicConfiguration
    {
        ILogicConfiguration Configuration { get; set; }
            
        IDictionary<string, IDatabaseTableConfiguration> Tables { get; set; }

        IDictionary<string, IBusinessLogic> DependentBusinessLogics { get; set; }
    }

}