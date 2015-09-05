using System.Runtime.CompilerServices;
using AutoMapper;
using DbCredentials.Bll.BusinessLogic;
using DbCredentials.Bll.Interfaces.BusinessModels;
using DbCredentials.Dal.GeneratedModels;

namespace DbCredentials.Bll.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public AutoMapperConfiguration()
        {
            Configure();
        }
        public void Configure()
        {
            ForIScopeModel();
            ForIProjectModel();
            
        }
        ScopeModelLogic srcLogic = new ScopeModelLogic();
        private void ForIProjectModel()
        {
            
//            Mapper.CreateMap<IProjectModel, Projects>().ForMember(dest => dest.ScopeId, opts => opts.MapFrom(src => srcLogic.GetScopeModelById(src.Scope))); ;
                
            Mapper.CreateMap<Projects, IProjectModel>().ForMember(dest => dest.Scope, opts => opts.MapFrom(src => srcLogic.GetScopeModelById(src.ScopeId)));
        }
        private void ForIScopeModel()
        {
            
            Mapper.CreateMap<Scopes, IScopeModel>();
            Mapper.CreateMap<IScopeModel, Scopes>();
            
        }

    
    }
}