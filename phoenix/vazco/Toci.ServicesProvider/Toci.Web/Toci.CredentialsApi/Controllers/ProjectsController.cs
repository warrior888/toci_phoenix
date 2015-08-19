using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCredentials.BusinessLogic;
using Toci.CredentialsApi.Models;

using DbCredentials.DbLogic.CredentialsModels;
namespace Toci.CredentialsApi.Controllers
{
    public class ProjectsController : ApiController
    {
        BusinessLogic businessLogic = new BusinessLogic();
        
        [Route("Save/Project")]
        [HttpPost]
        public string SaveProject(BusinessModel model)
        {
            try
            {
                return businessLogic.AddProject(model.GetScopesModel(), model.GetProjectsModel()) ? "Succeed" : "Failed";
            }
            catch (ApplicationException exception)
            {
                throw new ApplicationException("Cannot add project. "+ exception.Message);
            }
        }

        [Route("Load/Project")]
        [HttpPost]
        public ProjectsModel LoadProject(BusinessModel model)
        {
            try
            {
                ProjectsModel projectsModel = new ProjectsModel();
                var projectmodel = businessLogic.LoadProject(model.GetProjectsModel(),model.GetScopesList());
                return projectsModel.GetProjectElement(projectmodel);
            }
            catch (Exception exception)
            {
                throw new Exception("Cannot load project. " + exception.Message);
            }
        }

        [Route("Load/Projects")]
        [HttpPost]
        public List<ProjectsModel> LoadProjects(BusinessModel model)
        {
            try
            {
                ProjectsModel projectsModel = new ProjectsModel();
                var list = businessLogic.LoadProjects(model.GetScopesList());
                return projectsModel.GetProjectsList(list);
            }
            catch (Exception exception)
            {
                throw new Exception("Cannot load projects. " + exception.Message);
            }
        }

        [Route("Delete/Project")]
        [HttpPost]
        public bool DeleteProject(BusinessModel model)
        {
            try
            {
                return businessLogic.DeleteProject(model.GetProjectsModel(), model.GetScopesList());
            }
            catch (Exception exception)
            {
                throw new Exception("Cannot delete project. " + exception.Message);
            }
        }

        [Route("Update/Project")]
        [HttpPost]
        public bool UpdateProject(BusinessModel model)
        {
            try
            {
                 return businessLogic.UpdateProject(model.GetProjectsModel("Update"), model.GetScopesList());
            }
            catch (Exception exception)
            {
                throw new Exception("Cannot update project. " + exception.Message);
            }
        }

    }
}
