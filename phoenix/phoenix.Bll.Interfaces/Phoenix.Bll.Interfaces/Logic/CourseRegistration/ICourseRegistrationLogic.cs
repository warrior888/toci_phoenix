using System.Collections;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;

namespace Phoenix.Bll.Interfaces.Logic.CourseRegistration
{
    public interface ICourseRegistrationLogic
    {
        bool SaveParticipantRegistration(ICourseRegistrationBusinessModel registration);

        bool DeleteParticipantRegistration(ICourseRegistrationBusinessModel registration);

        bool MoveParticipantToUsers(ICourseRegistrationBusinessModel registeredParticipant);

        IEnumerable<IChosenCourseRegistrationBusinessModel> GetRegisteredUsers(int courseId);

        IEnumerable<ICoursesListBuisnessModel> GetParticipantChoosedCourses(int participantId);


    

    }
}