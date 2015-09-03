using AutoMapper;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Integration.Test.Developers.Patryk.AutoMapper
{
    public class Whatever
    {
        public course_registration DoMapping(ICourseRegistrationBusinessModel course)
        {
            return Mapper.Map<course_registration>(course);
        }

        public ICourseRegistrationBusinessModel DoMappingInOtherSide(course_registration course)
        {
            return Mapper.Map<ICourseRegistrationBusinessModel>(course);
        } 
    }
}