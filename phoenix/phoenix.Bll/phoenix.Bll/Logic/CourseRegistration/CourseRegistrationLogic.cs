using System;
using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;
using Phoenix.Bll.Interfaces.Logic.CourseRegistration;

namespace Phoenix.Bll.Logic.CourseRegistration
{
    public class CourseRegistrationLogic : DbLogic, ICourseRegistrationLogic
    {


        public bool SaveParticipantRegistration(ICourseRegistrationBusinessModel registration)
        {
            throw new NotImplementedException();
        }

        public bool DeleteParticipantRegistration(ICourseRegistrationBusinessModel registration)
        {
            throw new NotImplementedException();
        }

        public bool MoveParticipantToUsers(ICourseRegistrationBusinessModel registeredParticipant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IChosenCourseRegistrationBusinessModel> GetRegisteredUsers(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICoursesListBuisnessModel> GetParticipantChoosedCourses(int participantId)
        {
            throw new NotImplementedException();
        }
    }
}
