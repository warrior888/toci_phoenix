using System.Data.SqlClient;
using AutoMapper;
using log4net.Core;
using Phoenix.Bll.BusinessModels.TeamLeasing;
using Phoenix.Bll.BusinessModels.UsersList;
using Phoenix.Bll.Interfaces.BusinessModels.CourseRegistration;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.UsersList;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Bll.Logic.TeamLeasing;
using Phoenix.Bll.Logic.UsersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll
{
    public class AutoMapperConfiguration
    {
        //TODO DI

        private static IUsersLogic _userLogic = new UsersLogic();
        private static IDeveloperListLogic _developerListLogic = new DeveloperListLogic();
        private static IPortfolioLogic _portfolioLogic = new PortfolioLogic();
        private static ISkillLogic _skillLogic = new SkillLogic();
        private static IDeveloperAvailableLogic _availableLogic = new DeveloperAvailableLogic();

        public static void Configure()
        {
            ForICourseRegistrationBusinessModel();
            ForISkillBusinessModel();
            ForIPortfolioBusinessModel();
            ForIDeveloperAvailableBusinessModel();
            ForIDeveloperBusinessModel();

        }

        private static void ForICourseRegistrationBusinessModel()
        {
            Mapper.CreateMap<ICourseRegistrationBusinessModel, course_registration>();
            Mapper.CreateMap<course_registration, ICourseRegistrationBusinessModel>(); 
        }

        private static  void ForISkillBusinessModel()
        {
            Mapper.CreateMap<ISkillBusinessModel, skills_technologies>();
            Mapper.CreateMap<skills_technologies, ISkillBusinessModel>();

            Mapper.CreateMap<IDeveloperSkillBusinessModel, developer_skills_view>();
            Mapper.CreateMap<developer_skills_view, IDeveloperSkillBusinessModel>();

        }

        private static void ForIPortfolioBusinessModel()
        {
            Mapper.CreateMap<IPortfolioBusinessModel, portfolio>();
            Mapper.CreateMap<portfolio, IPortfolioBusinessModel>().
                ForMember(dest => dest.Skills, opts => opts.MapFrom(src => _skillLogic.GetPortfolioSkills(src.Id)));
        }

        private static void ForIDeveloperAvailableBusinessModel()
        {
            Mapper.CreateMap<IDeveloperAvailableBusinessModel, developers_available>();
            Mapper.CreateMap<developers_available, IDeveloperAvailableBusinessModel>();
        }

        private static void ForIDeveloperBusinessModel()
        {
            Mapper.CreateMap<IDeveloperBusinessModel, developer_list_view>();
            Mapper.CreateMap<developer_list_view, IDeveloperBusinessModel>().
                ForMember(dest => dest.User, opts => opts.MapFrom(src=> new UsersBusinessModel()
                {
                    Name = src.Name,
                    Surname = src.Surname,
                    Nick = src.Nick
                })).
                ForMember(dest => dest.DeveloperAvailable, opts => opts.MapFrom(src => new DeveloperAvailableBusinessModel()
                {
                    AvailableFor = src.AvailableFor,
                    EndWorkHour = src.EndWorkHour,
                    StartWorkHour = src.StartWorkHour
                })).
                ForMember(dest => dest.Portfolio, opts => opts.MapFrom(src => _portfolioLogic.GetUserPortfolio(src.UserId))).
                ForMember(dest => dest.Skills, opts => opts.MapFrom(src => _skillLogic.GetDeveloperSkills(src.UserId)));
        }
    }
}