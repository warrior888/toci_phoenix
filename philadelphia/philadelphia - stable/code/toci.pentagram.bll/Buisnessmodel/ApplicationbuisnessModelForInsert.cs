using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toci.pentagram.interfaces.buisnessModel;

namespace toci.pentagram.bll.Buisnessmodel
{
    public class ApplicationbuisnessModelForInsert:IApplicationtestBuisnessModelforInsert
    {
        public string Codesnipet { get; set; }
        public string Rightanswers { get; set; }
    }
}
