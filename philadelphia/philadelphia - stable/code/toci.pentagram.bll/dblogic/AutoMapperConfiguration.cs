using AutoMapper;
using Phoenix.Dal.GeneratedModels;
using toci.pentagram.bll.logic;
using toci.pentagram.Dal;
using toci.pentagram.interfaces;

namespace toci.pentagram.bll.dblogic
{
    public class AutoMapperConfiguration
    {
        //TODO DI
        private IApplicationTestsLogic _applicationtests;

        public AutoMapperConfiguration(IApplicationTestsLogic applicationtests)
        {
            _applicationtests = applicationtests;
        }
            public AutoMapperConfiguration()
        {
            _applicationtests = new ApplicationTestsLogic();
        }




        public void Configure()
        {
            ForApplicationTestsbuisnesModel();
            ForICourseRegistrationBusinessModel();

        }

        private void ForICourseRegistrationBusinessModel()
        {
            Mapper.CreateMap<ITestResultsBuisnessModel, TestsResults>();
            Mapper.CreateMap<TestsResults, ITestResultsBuisnessModel>().
          ForMember(dest => dest.applicationtests, opts => opts.MapFrom(src => _applicationtests.GetTestById(src.FkIdApplicationtests)));

           

        }
private void ForApplicationTestsbuisnesModel()
        {
            Mapper.CreateMap<IApplicationTestsBuisnessModel, ApplicationTests>();
    Mapper.CreateMap<ApplicationTests, IApplicationTestsBuisnessModel>();
         

           

        }



    }
}
