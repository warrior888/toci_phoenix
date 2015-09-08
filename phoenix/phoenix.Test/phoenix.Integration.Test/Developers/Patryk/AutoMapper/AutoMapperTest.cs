using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Integration.Test.Developers.Patryk.AutoMapper
{

    [TestClass]
    public class AutoMapperTest
    {

        [TestMethod]
        public void MapObjectWhenTheSameFieldsName()
        {
            ClassForMap classForMap = new ClassForMap()
            {
                Name = "Patryk",
                Ag  = 21
            };

            Mapper.CreateMap<ClassForMap, AnotherClassForMap>()
                .ForMember(dest => dest.Age, opts => opts.MapFrom(src => src.Ag));
            AnotherClassForMap anotherObjectForMap = Mapper.Map<AnotherClassForMap>(classForMap);
        }


        [TestMethod]
        public void MapObjectWhenOtherFieldsName()
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
            course_registration courseRegistration = new course_registration();
            courseRegistration = Mapper.Map<course_registration>(registrationBusinessModel);
        }         
    }
}