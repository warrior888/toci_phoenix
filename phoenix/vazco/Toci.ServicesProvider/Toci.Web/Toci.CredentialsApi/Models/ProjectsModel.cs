using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.BusinessLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace Toci.CredentialsApi.Models
{
    public class ProjectsModel
    {

        public int projectId { get; set; }
        public string projectName { get; set; }
        public string scopeName { get; set; }
        public string projectAuthor { get; set; }
        public string projectData { get; set; }
        public DateTime modificationdate { get; set; }

        public List<ProjectsModel> GetProjectsList(List<Projects> list)
        {
            return list.Select(GetProjectElement).ToList();
        }

        public ProjectsModel GetProjectElement(Projects model)
        {
            var scope = new ScopesLogic(new VazcoDbConfig());
            return new ProjectsModel
            {
                scopeName = scope.GetScopesName(model.scopeid),
                projectId = model.projectid,
                projectName = model.projectname,
                projectData = model.projectdata,
                projectAuthor = model.projectauthor,
                modificationdate = model.modificationdate
            };
        }
    }
}