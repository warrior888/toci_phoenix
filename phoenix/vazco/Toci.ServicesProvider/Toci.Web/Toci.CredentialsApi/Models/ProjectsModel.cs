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

        public List<Dictionary<string, string>> GetProjectsList(List<Projects> list)
        {
            return list.Select(GetProjectElement).ToList();
        }

        public Dictionary<string, string> GetProjectElement(Projects model)
        {
            var scope = new ScopesLogic(new VazcoDbConfig());
            return new Dictionary<string, string>()
            {
                { "scopeName", scope.GetScopesName(model.scopeid) },
                { "projectId", model.projectid.ToString() },
                { "projectName" , model.projectname },
                { "projectData" , model.projectdata },
                { "projectAuthor" , model.projectauthor },
                { "modificationdate" , model.modificationdate.ToString() }
            };
        }
    }
}