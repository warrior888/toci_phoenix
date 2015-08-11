using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.BusinessLogic
{
    class BusinessLogic
    {
        ScopesLogic scopesLogic = new ScopesLogic();
        ProjectsLogic projectsLogic = new ProjectsLogic();

        public bool AddProject(Scopes scopesModel, Projects projectsModel)
        {
            return scopesLogic.AddScope(scopesModel) && projectsLogic.AddProject(projectsModel);
        }

        public bool IsProjectExist(Projects model)
        {
            return projectsLogic.IsProjectExist(model);
        }

        public Projects LoadProject(Projects model, List<Scopes> listOfModels)
        {
            return projectsLogic.LoadProject(model, listOfModels);
        }

        public List<Projects> LoadProject(List<Scopes> listOfModels)
        {
            return projectsLogic.LoadProjects(listOfModels);
        }

        public bool DeleteProject(Projects model, List<Scopes> listOfModels)
        {
            return projectsLogic.DeleteProject(model, listOfModels);
        }

        public bool UpdateProject(Projects model, List<Scopes> listOfModels)
        {
            return projectsLogic.UpdateProject(model, listOfModels);
        }

    }
}
