using System.Collections.Generic;

namespace Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons
{
    public interface IViewConfiguration
    {
        ILogicConfiguration Configuration { get; set; }

        IDictionary<string, IDatabaseTableConfiguration> Tables { get; set; }
    }
}