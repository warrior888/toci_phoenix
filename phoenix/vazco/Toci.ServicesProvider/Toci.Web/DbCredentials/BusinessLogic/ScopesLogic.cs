using System.Linq;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.BusinessLogic
{
    public class ScopesLogic
    {
        private const int notSaved = 0;
        private const bool exist = true;
        DbQuery dbQuery = new DbQuery();

        public bool AddScope(Scopes model)
        { 
            return IsScopeExist(model)||dbQuery.Save(model) != notSaved;
        }

        public bool IsScopeExist(Scopes model)
        {
            var list = dbQuery.Load(model).Cast<Scopes>().ToList();
            return list.Any(item => item.scopename.Equals(model.scopename));
        }

        public Scopes GetScopeId(Scopes model)
        {
            if (!IsScopeExist(model))
            {
                return model;
            }

            var list = dbQuery.Load(model).Cast<Scopes>().ToList();

            foreach (var item in list.Where(item => item.scopename.Equals(model.scopename)))
            {
                model.scopeid = item.scopeid;
                return model;
            }

            //list.Any(item => item.scopename.Equals(model.scopename) model.scopeid = item.scopeid);
            return model; 
                 
        }
    }
}