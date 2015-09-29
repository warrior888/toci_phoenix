using System.Collections.Generic;
using System.Linq;
using DbCredentials.Bll.AccessConfig;
using DbCredentials.Bll.Interfaces.BusinessLogic;
using DbCredentials.Bll.Interfaces.BusinessModels;
using DbCredentials.Dal.GeneratedModels;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization;


namespace DbCredentials.Bll.BusinessLogic
{
    public class ScopeModelLogic: VazcoAccessConfig
    { 

        public IScopeModel GetScopeModelByScopeId(int scopeId)
        {
            return GetElementsByColumnValue<IScopeModel, Scopes, int>(Scopes.SCOPEID, SelectClause.Equal, scopeId)[0];
        }
        public IScopeModel GetScopeModelByScopeName(string scopeName)
        {
            return GetElementsByColumnValue<IScopeModel, Scopes, string>(Scopes.SCOPENAME, SelectClause.Equal, scopeName)[0];
        }
        public void AddScopeModelList(List<Scopes> scopesList)
        {
            foreach (var scope in scopesList)
            {
                InsertScopeModel(scope);
            }
        }

        public int InsertScopeModel(Scopes model)
        {
            return !IsScopeNameExist(model)? InsertModel(model):0;
        }

        public bool IsScopeNameExist(Scopes model)
        {
            return GetAllElements<IScopeModel, Scopes>().Any(item => model.ScopeName.Equals(item.ScopeName));
        }

        //        public bool IsScopeNameExist(Scopes model)
        //        {
        //            return GetElementsByColumnValue<IScopeModel, Scopes, string>(Scopes.SCOPENAME, SelectClause.Equal, model.ScopeName)!=null;
        //        }

    }
}