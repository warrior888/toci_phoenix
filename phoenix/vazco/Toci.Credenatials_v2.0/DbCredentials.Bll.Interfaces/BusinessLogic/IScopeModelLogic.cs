using DbCredentials.Bll.Interfaces.BusinessModels;

namespace DbCredentials.Bll.Interfaces.BusinessLogic
{
    public interface IScopeModelLogic
    {
        IScopeModel GetScopeModelById(int Id);
        
    }
}