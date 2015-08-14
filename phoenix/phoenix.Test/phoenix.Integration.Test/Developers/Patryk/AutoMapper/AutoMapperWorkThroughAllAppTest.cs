using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Integration.Test.Developers.Patryk.AutoMapper
{
    [TestClass]
    public class AutoMapperWorkThroughAllAppTest
    {
        [TestMethod]
        public void MapObjectWhenCreateMapInAnotherClass()
        {
            ICourseRegistrationBusinessModel registrationBusinessModel = new CourseRegistrationBusinessModel()
            {
                Role = 1,
                Login = "login",
                Password = "password",
                Email = "email@gmail.com",
                Nick = "nick",
                Name = "name",
                Surname = "surname"
            };
            Mapper.CreateMap<ICourseRegistrationBusinessModel, course_registration>();
            Whatever whatever = new Whatever();
            course_registration course = whatever.DoMapping(registrationBusinessModel);
           // ICourseRegistrationBusinessModel courseBusinessModel = whatever.DoMapping(course);
        } 
         
    }
}