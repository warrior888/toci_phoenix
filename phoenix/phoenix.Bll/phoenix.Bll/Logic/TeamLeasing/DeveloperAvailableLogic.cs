using AutoMapper;
using Phoenix.Bll.Interfaces.BusinessModels.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.TeamLeasing
{
    public class DeveloperAvailableLogic : DbLogic, IDeveloperAvailableLogic
    {
        public IDeveloperAvailableBusinessModel GetDeveloperAvailableById(int id)
        {
            var devAvailableModel = FetchModelById<developers_available>(id);

            Mapper.CreateMap<developers_available, IDeveloperAvailableBusinessModel>()
                  .ForMember(dest => dest.AvailableFor, opt => opt.MapFrom(src => src.AvailbleFor));
             
            return Mapper.Map<IDeveloperAvailableBusinessModel>(devAvailableModel);
        }
    }
}