using System.Collections;
using System.Collections.Generic;

namespace Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration
{
    public interface ICourseRegistrationBusinessModel
    {
        IEnumerable<IChosenCourseRegistrationBusinessModel> ChosenCoures { get; set; }
    }
}