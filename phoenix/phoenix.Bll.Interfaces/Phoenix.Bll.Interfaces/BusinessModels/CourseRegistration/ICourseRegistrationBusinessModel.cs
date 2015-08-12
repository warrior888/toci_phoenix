using System.Collections;
using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration
{
    public interface ICourseRegistrationBusinessModel
    {

        //string Role {get;set;}
        int Role {get;set;}
        string Login { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        string Nick { get; set; }
        string Name { get; set; }
        string Surname { get; set; }

        //IEnumerable<IChosenCourseRegistrationBusinessModel> ChosenCourses { get; set; }
    }
}