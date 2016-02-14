using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class ViewConfiguration : IViewConfiguration
    {
        public ILogicConfiguration Configuration { get; set; }
        public IDictionary<string, IDatabaseTableConfiguration> Tables { get; set; }
    }
}