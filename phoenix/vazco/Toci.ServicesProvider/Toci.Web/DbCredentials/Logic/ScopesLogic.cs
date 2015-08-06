using System;
using System.Linq;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.Logic
{
    public class ScopesLogic
    {
        private const int notSaved = 0;
        private const bool exist = true;
        DbQuery dbQuery = new DbQuery();

        public bool AddProject(Scopes model)
        {
            var list = dbQuery.Load(model).Cast<Scopes>().ToList();
            if (list.Any(item => item.scopename.Equals(model.scopename)))
            {
                return exist;
            }
            return dbQuery.Save(model) != notSaved;
        }
    }
}