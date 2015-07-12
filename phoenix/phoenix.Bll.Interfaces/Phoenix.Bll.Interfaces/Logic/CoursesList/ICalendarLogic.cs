using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Bll.Interfaces.Logic.CoursesList
{
    public interface ICalendarLogic
    {
        ICoursesListBuisnessModel GetCourseById(IEnumerable<ICoursesListBuisnessModel> courseList, int courseId);
        ICoursesListBuisnessModel GetCourseByTechnologies(IEnumerable<ICoursesListBuisnessModel> courseList, string coursTechnologies);
        bool AddCourse(ICoursesListBuisnessModel course);
        bool DeleteCourse(ICoursesListBuisnessModel course);
        ICoursesListBuisnessModel GetCoursesList(IEnumerable<ICoursesListBuisnessModel> courseList);


    }
}
