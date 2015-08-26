using System;
using System.Linq;
using DbCredentials.Config;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using ErrorsAndMessages.Exceptions;

namespace DbCredentials.BusinessLogic
{
    public class BusinessLogicUtills
    {
        DbQuery dbQuery;

        public BusinessLogicUtills(DbConfig dbConfig)
        {
            dbQuery = new DbQuery(dbConfig);
        }
        public bool IsProjectExist(int projectId)
        {
            Projects model = new Projects
            {
                projectid = projectId
            };
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            return list.Any(item => item.projectid.Equals(projectId));
        }
        public bool IsProjectExist(string projectName)
        {
            Projects model = new Projects
            {
                projectname = projectName
            };
            try
            {
                var list = dbQuery.Load(model).Cast<Projects>().ToList();
                return list.Any(item => item.projectname.Equals(model.projectname));
            }
            catch (Exception)
            {
                throw new WebApiTociApplicationException("Cannot load project list.", null, (int)ApiErrors.WrongData);
            }
        }
        
        public void ValidateProjectNameExsiting(Projects model)
        {
            if (IsProjectExist(model.projectname))
            {
                throw new WebApiTociApplicationException("Project name exist.", null, (int)ApiErrors.WrongData);
            }
        }

        public void ValidateProjectExsiting(Projects model)
        {
            if (!IsProjectExist(model.projectname))
            {
                throw new WebApiTociApplicationException("Project does not exist.", null, (int)ApiErrors.DataMissing);
            }
        }

        public void ValidateProjectExsitingById(Projects model)
        {
            if (!IsProjectExist(model.projectid))
            {
                throw new WebApiTociApplicationException("Project does not exist.", null, (int)ApiErrors.DataMissing);
            }
        }

        public Projects GetProjectName(Projects model, int projectid)
        {
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            var newmodel = new Projects();
            model.projectid = projectid;
            foreach (var item in list.Where(item => item.projectid.Equals(model.projectid)))
            {
                newmodel.projectname = item.projectname;
            }
            return newmodel;
        }
    }
}
