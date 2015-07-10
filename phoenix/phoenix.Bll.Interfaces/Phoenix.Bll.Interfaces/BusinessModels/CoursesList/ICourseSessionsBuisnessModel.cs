using _3mb.Bll.Interfaces.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Bll.Interfaces.BusinessModels.CoursesList
{
    interface ICourseSessionsBuisnessModel
    {
        string SessionName { get; set; }
        double SessionCount { get; set; }
        DateTime StartSession { get; set; }
        DateTime EndSession { get; set; }
        IEnumerable<IPhoenixUser> Users { get; set; }
    }
}
