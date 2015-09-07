using AutoMapper;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.BusinessModels.UsersList;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.UsersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll
{
    public class AutoMapperConfiguration
    {
        private IUsersLogic _userLogic;
        private IDeveloperListLogic _developerListLogic;
        private IPortfolioLogic _portfolioLogic;
        private ISkillLogic _skillLogic;
        private IDeveloperAvailableLogic _availableLogic;

        public AutoMapperConfiguration(
            IUsersLogic usersLogic,
            IDeveloperListLogic developerListLogic,
            IPortfolioLogic portfolioLogic,
            ISkillLogic skillLogic,
            IDeveloperAvailableLogic developerAvailableLogic
            )
        {
            _userLogic = usersLogic;
            _developerListLogic = developerListLogic;
            _portfolioLogic = portfolioLogic;
            _skillLogic = skillLogic;
            _availableLogic = developerAvailableLogic;

            Configure();
        }

        public void Configure()
        {
            ForICourseRegistrationBusinessModel();
            ForISkillBusinessModel();
            ForIPortfolioBusinessModel();
            ForIDeveloperAvailableBusinessModel();
            ForIDeveloperBusinessModel();

        }

        private void ForICourseRegistrationBusinessModel()
        {
            Mapper.CreateMap<ICourseRegistrationBusinessModel, course_registration>();
            Mapper.CreateMap<course_registration, ICourseRegistrationBusinessModel>(); 
        }

        private void ForISkillBusinessModel()
        {
            Mapper.CreateMap<ISkillBusinessModel, skills_technologies>();
            Mapper.CreateMap<skills_technologies, ISkillBusinessModel>();

            Mapper.CreateMap<IDeveloperSkillBusinessModel, developer_skills_view>();
            Mapper.CreateMap<developer_skills_view, IDeveloperSkillBusinessModel>();

        }

        private void ForIPortfolioBusinessModel()
        {
            Mapper.CreateMap<IPortfolioBusinessModel, portfolio>();
            Mapper.CreateMap<portfolio, IPortfolioBusinessModel>().
                ForMember(dest => dest.Skills, opts => opts.MapFrom(src => _skillLogic.GetPortfolioSkills(src.Id)));
        }

        private void ForIDeveloperAvailableBusinessModel()
        {
            Mapper.CreateMap<IDeveloperAvailableBusinessModel, developers_available>()
                .ForMember(dest => dest.AvailableFrom, opt => opt.MapFrom(src => src.AvailableFrom))
                .ForMember(dest => dest.AvailableTo, opt => opt.MapFrom(src => src.AvailableTo)); 
            Mapper.CreateMap<developers_available, IDeveloperAvailableBusinessModel>()
                .ForMember(dest => dest.AvailableFrom, opt => opt.MapFrom(src => src.AvailableFrom))
                .ForMember(dest => dest.AvailableTo, opt => opt.MapFrom(src => src.AvailableTo));

        }

        private void ForIDeveloperBusinessModel()
        {                    
            Mapper.CreateMap<developer_list_view, IDeveloperBusinessModel>().
                ForMember(dest => dest.User, opts => opts.MapFrom(src=> new UsersBusinessModel()
                {
                    Id = src.UserId,
                    Name = src.Name,
                    Surname = src.Surname,
                    Nick = src.Nick
                })).
                ForMember(dest => dest.DeveloperAvailable, opts => opts.MapFrom(src => new DeveloperAvailableBusinessModel()
                {
                    Id = src.Id,
                    AvailableFrom = src.AvailableFrom,
                    AvailableTo = src.AvailableTo,
                    EndWorkHour = src.EndWorkHour,
                    StartWorkHour = src.StartWorkHour
                })).
                ForMember(dest => dest.Portfolio, opts => opts.MapFrom(src => _portfolioLogic.GetUserPortfolio(src.UserId))).
                ForMember(dest => dest.Skills, opts => opts.MapFrom(src => _skillLogic.GetDeveloperSkills(src.UserId)));
        }
    }
}