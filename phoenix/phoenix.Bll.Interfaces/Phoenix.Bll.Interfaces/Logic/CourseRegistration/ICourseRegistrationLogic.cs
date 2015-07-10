using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;

namespace Phoenix.Bll.Interfaces.Logic.CourseRegistration
{
    public interface ICourseRegistrationLogic
    {
        bool SaveRegistration(ICourseRegistrationBusinessModel registration);
    }
}