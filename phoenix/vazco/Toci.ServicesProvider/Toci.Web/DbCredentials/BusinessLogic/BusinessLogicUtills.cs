using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.ErrorsAndMessages.Exceptions;

namespace DbCredentials.BusinessLogic
{
    public class BusinessLogicUtills
    {
        DbQuery dbQuery = new DbQuery();
        public bool IsProjectExist(int projectId)
        {
            Projects model = new Projects
            {
                projectid = projectId
            };
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            return list.Any(item => item.projectname.Equals(model.projectname));
        }
        public bool IsProjectExist(string projectName)
        {
            Projects model = new Projects
            {
                projectname = projectName
            };
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            return list.Any(item => item.projectname.Equals(model.projectname));
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
    }
}
