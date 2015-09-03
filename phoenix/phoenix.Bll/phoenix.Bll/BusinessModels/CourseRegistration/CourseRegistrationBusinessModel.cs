using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;

namespace Phoenix.Bll.BusinessModels.CourseRegistration
{
    public class CourseRegistrationBusinessModel : ICourseRegistrationBusinessModel
    {
        //public string Role { get; set; }
        public int Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public IEnumerable<IChosenCourseRegistrationBusinessModel> ChosenCourses { get; set; }
        
    }
}