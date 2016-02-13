using System.Collections.Generic;
using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class BusinessLogicConfiguration :  IBusinessLogicConfiguration
    {
        public IDictionary<string, IDatabaseColumn> Constraints { get; set; }
        public void DelegateEmployee(IDatabaseColumn column)
        {
            throw new System.NotImplementedException();
        }
    }

}