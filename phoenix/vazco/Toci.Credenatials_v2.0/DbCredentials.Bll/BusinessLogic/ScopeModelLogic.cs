using DbCredentials.Bll.Interfaces.BusinessLogic;
using DbCredentials.Bll.Interfaces.BusinessModels;
using DbCredentials.Dal.GeneratedModels;
using Toci.Db.DbUtils;

namespace DbCredentials.Bll.BusinessLogic
{
    public class ScopeModelLogic: DataAccessLogic, IScopeModelLogic
    {
        public IScopeModel GetScopeModelById(int Id)
        {
            return GetElementById<IScopeModel, Scopes>(Id);
        }
    }
}