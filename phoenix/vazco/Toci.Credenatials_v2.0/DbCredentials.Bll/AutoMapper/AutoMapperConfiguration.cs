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
            
            //Gdy właściwości mają takie same nazwy nic więcej nie trzeba robić
            Mapper.CreateMap<IProjectModel, Projects>();
                
            Mapper.CreateMap<Projects, IProjectModel>().ForMember(dest => dest.Scope, opts => opts.MapFrom(src => srcLogic.GetScopeModelById(src.ScopeId)));
        }
        private void ForIScopeModel()
        {
            //Gdy właściwości mają takie same nazwy nic więcej nie trzeba robić
            Mapper.CreateMap<Scopes, IScopeModel>();
            Mapper.CreateMap<IScopeModel, Scopes>();
            
        }

    
    }
}