using _3mb.Bll.Interfaces.User;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;
using System.Collections.Generic;
using Toci.Db.Interfaces;

namespace Phoenix.Bll.Interfaces.Logic.CoursesList
{
    public interface ICoursesListLogic : IDbLogic
    {
        bool AddSession(ICourseSessionsBuisnessModel session);
        //bool EditSession(ICourseSessionsBuisnessModel session);
        bool DeleteSession(ICourseSessionsBuisnessModel session);

        bool SetCourseStart(ICoursesListBuisnessModel course);

        bool AddCourseAgenda(string agenda, ICoursesListBuisnessModel course);
        bool DeleteAgenda(ICoursesListBuisnessModel course);
        
        IEnumerable<IPhoenixUser> GetCourseTrainers(ICoursesListBuisnessModel course);
        bool AddTrainerToCourse(IPhoenixUser user);
        bool DeleteTrainerFromCourse(IPhoenixUser user);                                     
        
        bool AddCourseTechnologie(string technologie, ICoursesListBuisnessModel course);
        bool EditCourseTechnologie(ICoursesListBuisnessModel course);
        bool DeleteCourseTechnologies(ICoursesListBuisnessModel course);

        IEnumerable<IPhoenixUser> GetCourseUsers(ICoursesListBuisnessModel course);
        bool AddUserToCourse(IPhoenixUser user);
        bool DeleteUserFromCourse(IPhoenixUser user);

        bool GetFromThirdyPartyCalendar(IPhoenixUser user);
        bool SaveToThirdPartyCalendar(ICoursesListBuisnessModel course);

         // nasz i course list busines model GetFromThirdPartyCalendar();

        // SaveToThirdPartyCalendar(i course list busines model ???);
    }
}