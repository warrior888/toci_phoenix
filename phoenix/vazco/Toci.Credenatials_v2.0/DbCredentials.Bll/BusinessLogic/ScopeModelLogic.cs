using System.Collections.Generic;
using System.Linq;
using DbCredentials.Bll.Interfaces.BusinessLogic;
using DbCredentials.Bll.Interfaces.BusinessModels;
using DbCredentials.Dal.GeneratedModels;
using Toci.Db.ClusterAccess;
using Toci.Db.DbUtils;
using Toci.Db.DbVirtualization;

namespace DbCredentials.Bll.BusinessLogic
{
    public class ScopeModelLogic: DataAccessLogic, IScopeModelLogic
    {

        

        private static DbAccessConfig DatabaseAccess()
        {
            return new DbAccessConfig
            {
                Password = "localhost",
                DbAddress = "localhost",
                DbName = "ImportatStuffDb",
                UserName = "postgres"
            };
        }

        public IScopeModel GetScopeModelById(int Id)
        {
            return GetElementById<IScopeModel, Scopes>(Id);
        }

        public int InsertScopeModel(Scopes model)
        {
            return IsScopeNameExist(model)?InsertModel(model):0;
        }

//        public bool IsScopeNameExist(Scopes model)
//        {
//            return GetElementsByColumnValue<IScopeModel, Scopes, string>(Scopes.SCOPENAME, SelectClause.Equal, model.ScopeName)!=null;
//        }
        public bool IsScopeNameExist(Scopes model)
        {
            return GetAllElements<IScopeModel, Scopes>().Any(item => model.ScopeName.Equals(item.ScopeName));
        }
    }
}