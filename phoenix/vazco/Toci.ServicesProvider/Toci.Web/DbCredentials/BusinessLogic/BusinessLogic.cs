using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.BusinessLogic
{
    public class BusinessLogic
    {
        ScopesLogic scopesLogic = new ScopesLogic();
        ProjectsLogic projectsLogic = new ProjectsLogic();

        public bool AddProject(Scopes scopesModel, Projects projectsModel)
        {
            if (!scopesLogic.AddScope(scopesModel))
            {
                return false;
            }
            projectsModel.scopeid = scopesLogic.GetScopeId(scopesModel).scopeid;

            return  projectsLogic.AddProject(projectsModel);
        }

        public Projects LoadProject(Projects model, List<Scopes> listOfScopes)
        {
            return projectsLogic.LoadProject(model, listOfScopes);
        }

        public List<Projects> LoadProjects(List<Scopes> listOfScopes)
        {
            return projectsLogic.LoadProjects(listOfScopes);
        }

        public bool DeleteProject(Projects model, List<Scopes> listOfScopes)
        {
            return projectsLogic.DeleteProject(model, listOfScopes);
        }

        public bool UpdateProject(Projects model, List<Scopes> listOfScopes)
        {
            return projectsLogic.UpdateProject(model, listOfScopes);
        }

        public List<Scopes> LoadScopes(Scopes model)
        {
            return scopesLogic.LoadScopes(model);
        }

        

    }
}
