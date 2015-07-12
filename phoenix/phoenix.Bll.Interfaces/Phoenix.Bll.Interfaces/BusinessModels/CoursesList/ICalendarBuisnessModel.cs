using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Bll.Interfaces.BusinessModels.CoursesList
{
    public interface ICalendarBuisnessModel
    {
        IEnumerable<ICoursesListBuisnessModel> CoursesList { get; set; }        
        
    }
}
