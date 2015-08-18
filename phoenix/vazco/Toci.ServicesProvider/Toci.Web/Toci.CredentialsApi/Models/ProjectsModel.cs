using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.DbLogic.CredentialsModels;

namespace Toci.CredentialsApi.Models
{
    public class ProjectsModel
    {

        public int projectId { get; set; }
        public string projectName { get; set; }
        public string projectAuthor { get; set; }
        public string projectData { get; set; }
        public DateTime modificationdate { get; set; }

        public List<ProjectsModel> GetProjectsList(List<Projects> list)
        {
            return list.Select(item => new ProjectsModel
            {
                projectId = item.projectid,
                projectName = item.projectname, 
                projectData = item.projectdata, 
                projectAuthor = item.projectauthor, 
                modificationdate = item.modificationdate
            }).ToList();
        }

        public ProjectsModel GetProjectElement(Projects model)
        {
            return new ProjectsModel
            {
                projectId = model.projectid,
                projectName = model.projectname,
                projectData = model.projectdata,
                projectAuthor = model.projectauthor,
                modificationdate = model.modificationdate
            };
        }
    }
}