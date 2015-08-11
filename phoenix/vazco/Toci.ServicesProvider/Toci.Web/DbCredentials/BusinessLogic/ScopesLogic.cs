using System;
using System.Collections.Generic;
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
            if (IsScopeExist(model))
            {
                return exist;
            }
            return dbQuery.Save(model) != notSaved;
        }

        public bool IsScopeExist(Scopes model)
        {
            var list = dbQuery.Load(model).Cast<Scopes>().ToList();
            return list.Any(item => item.scopename.Equals(model.scopename));
        }

        public Scopes GetScopeId(Scopes model)
        {
            AddScope(model);

            var list = dbQuery.Load(model).Cast<Scopes>().ToList();

            foreach (var item in list.Where(item => item.scopename.Equals(model.scopename)))
            {
                model.scopeid = item.scopeid;
                return model;
            }

            //list.Any(item => item.scopename.Equals(model.scopename) model.scopeid = item.scopeid);
            return model;     
        }

        public List<Scopes> GetScopesId(List<Scopes> scopesList)
        {
            return scopesList.Select(GetScopeId).ToList();
        }
    }
}