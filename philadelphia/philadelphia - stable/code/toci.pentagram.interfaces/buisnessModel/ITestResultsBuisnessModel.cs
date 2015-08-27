using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toci.pentagram.interfaces
{
    public interface ITestResultsBuisnessModel
    {
        IApplicationTestsBuisnessModel applicationtests { get; set; }
        string IdUser { get; set; }
        string Result { get; set; }
    }
}
