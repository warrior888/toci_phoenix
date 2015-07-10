using _3mb.Bll.Interfaces.User;
using Phoenix.Bll.Interfaces.BusinessModels.CoursesList;
using System.Collections.Generic;
namespace Phoenix.Bll.Interfaces.Logic.CoursesList
{
    public interface ICoursesListLogic : IDbLogic
    {
        bool AddSession(ICourseSessionsBuisnessModel session);
        bool EditSession(ICourseSessionsBuisnessModel session);
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
        bool DeleteUserFromCourse(IPhoenixUser user)




         // nasz i course list busines model GetFromThirdPartyCalendar();

        // SaveToThirdPartyCalendar(i course list busines model ???);
    }
}