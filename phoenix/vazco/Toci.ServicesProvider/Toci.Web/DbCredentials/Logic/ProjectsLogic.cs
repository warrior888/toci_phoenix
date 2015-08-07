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
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            if (list.Any(item => item.projectname.Equals(model.projectname)))
            {
                throw new Exception("Project exist");
            }
            return dbQuery.Save(model) != notSaved;
        }
    }
}