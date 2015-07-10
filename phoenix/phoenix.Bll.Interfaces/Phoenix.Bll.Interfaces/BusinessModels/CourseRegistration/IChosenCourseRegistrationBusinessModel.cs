using System;
using System.Collections;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;
using _3mb.Bll.Interfaces.User;

namespace Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration
{
    public interface IChosenCourseRegistrationBusinessModel
    {
        ICoursesListBusinessModel CourseInfo { get; set; }

    }
}