using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toci.pentagram.interfaces
{
    public interface IApplicationTestsBuisnessModel
    {   
        int Id { get; set; }

        string Codesnipet { get; set; }

        string Rightanswers { get; set; }
    }
}
