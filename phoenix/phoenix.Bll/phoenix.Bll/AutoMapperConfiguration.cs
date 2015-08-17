using AutoMapper;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ForICourseRegistrationBusinessModel();
            ForISkillBusinessModel();
            ForIPortfolioBusinessModel();
            
        }

        private static void ForICourseRegistrationBusinessModel()
        {
            Mapper.CreateMap<ICourseRegistrationBusinessModel, course_registration>();
            Mapper.CreateMap<course_registration, ICourseRegistrationBusinessModel>(); 
        }

        private static  void ForISkillBusinessModel()
        {
            Mapper.CreateMap<IDeveloperSkillBusinessModel, skills_technologies>();
            Mapper.CreateMap<skills_technologies, IDeveloperSkillBusinessModel>().
                ForMember(dest => dest.SkillName, opts => opts.MapFrom(src => src.TechName) ); 
        }

        private static void ForIPortfolioBusinessModel()
        {
            IDeveloperSkillLogic skillLogic = new DeveloperSkillLogic();
            Mapper.CreateMap<IPortfolioBusinessModel, portfolio>();
            Mapper.CreateMap<portfolio, IPortfolioBusinessModel>().
                ForMember(dest => dest.StartDate, opts => opts.MapFrom(src => src.ProjectStartDate)).
                ForMember(dest => dest.EndDate, opts => opts.MapFrom(src => src.ProjectCompletionDate)).
                ForMember(dest => dest.Skills, opts => opts.MapFrom(src => skillLogic.GetPortfolioSkills(src.Id)));
        }
    }
}