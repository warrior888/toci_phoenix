using System;
using System.Linq;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.Logic
{
    public class ProjectsLogic
    {
        private const int notSaved = 0;
        private const bool failure = false;
        DbQuery dbQuery = new DbQuery();

        public bool AddProject(Projects model)
        {
            return IsProjectExist(model) || dbQuery.Save(model) != notSaved;
        }

        public bool IsProjectExist(Projects model)
        {
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            return list.Any(item => item.projectname.Equals(model.projectname));
        }
    }
}