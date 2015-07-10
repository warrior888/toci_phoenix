using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3mb.Bll.Interfaces.User;

namespace Phoenix.Bll.Interfaces.BusinessModels.CoursesList
{
    public interface ICoursesListBuisnessModel
    {
        int CoursLength { get; set; }
        DateTime CourseStartDate { get; set; }
        string CourseAgenda { get; set; }

        IEnumerable<string> CourseTechnologies { get; set; }
        IEnumerable<ICourseSessionsBuisnessModel> CourseSessions { get; set; }
        IEnumerable<IPhoenixUser> CourseParticipants { get; set; } 
        IEnumerable<IPhoenixUser> CourseTrainers { get; set; } 

    }
}
