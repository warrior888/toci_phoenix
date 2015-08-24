

using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.BusinessLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace Toci.CredentialsApi.Models
{
    public class BusinessModel
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string projectAuthor { get; set; }  
        public string scopeName { get; set; }  
        public string projectData { get; set; }

        public string scopesList { get; set; }

        public static string separator = ", ";

        public Projects GetProjectsModel()
        {
            return new Projects
            {
                projectauthor = projectAuthor,
                projectdata = projectData,
                projectname = projectName,
            };
        }
        public Projects GetProjectsModel(string update)
        {
            
            ScopesLogic scope = new ScopesLogic(new VazcoDbConfig());
            return new Projects
            {
                projectauthor = projectAuthor,
                projectdata = projectData,
                projectname = projectName,
                projectid = projectId,
                scopeid = scope.GetScopeId(new Scopes {scopename = scopeName}).scopeid
            };
        }
        public Scopes GetScopesModel()
        {
           return new Scopes
           {
                scopename = scopeName
           }; 
        }

        public List<Scopes> GetScopesList()
        {
            try
            {
                
                var list = scopesList.Split(new[] {separator}, StringSplitOptions.None).ToList();
                return list.Select(item => new Scopes {scopename = item}).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Invalid scopesList.");
            }
        }
        
    }
}