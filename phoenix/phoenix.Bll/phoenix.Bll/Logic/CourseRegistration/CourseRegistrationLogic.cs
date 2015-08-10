using System;
using System.Collections.Generic;
using System.Linq;
//using AutoMapper;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;
using Phoenix.Bll.Interfaces.Logic.CourseRegistration;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.CourseRegistration
{
    public class CourseRegistrationLogic : DbLogic, ICourseRegistrationLogic
    {
        public bool SaveParticipantRegistration(ICourseRegistrationBusinessModel registration)
        {
            var courses = registration.ChosenCourses.Aggregate("", (current, item) => current + item);

            // AutoMapper
            //Mapper.CreateMap<ICourseRegistrationBusinessModel, course_registration>();
            //course_registration courseRegistration = Mapper.Map<course_registration>(registration);

            //DbHandle.InsertData(courseRegistration);
        
            //nie AutoMapper
            DbHandle.InsertData(new course_registration()
            {   //id?
                email = registration.Email,
                id_roles = Convert.ToInt32(registration.Role),
                login = registration.Login,
                name = registration.Name,
                nick = registration.Nick,
                password = registration.Password,
                surname = registration.Surname
            });

            DbHandle.InsertData(new courses_list()
            {   //id ?
                course_name = courses
            });

            return (DbHandle.InsertData(new chosen_course_registration()
            {
                //id?

            })) != 0;//nie wiem czy dobry warunek
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
