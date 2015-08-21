using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbCredentials.BusinessLogic;
using DbCredentials.DbLogic;
using Toci.CredentialsApi.Models;
using Toci.Utilities.Api;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.Utilities.Common.Exceptions;

namespace Toci.CredentialsApi.Controllers
{
    public class ProjectsController : ApiController
    {
        BusinessLogic businessLogic = new BusinessLogic(new VazcoDbConfig());
        ApiSimpleResultManager ResultManager = new ApiSimpleResultManager();

        [Route("Save/Project")]
        [HttpPost]
        public Dictionary<string, object> SaveProject(BusinessModel model)
        {
            try
            {
                businessLogic.AddProject(model.GetScopesModel(), model.GetProjectsModel());
                return ResultManager.GetApiResult(new SimpleResult { Code = 0, Message = "Saved!" }, "Json");
            }
            catch (TociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex),
                ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Save unsuccessfull." }, "Json");
            }
            catch (Exception)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Message = "Save unsuccessfull."
                }, "Json");
            }
        }

        [Route("Load/Project")]
        [HttpPost]
        public Dictionary<string, object> LoadProject(BusinessModel model)
        {
            try
            {
                ProjectsModel projectsModel = new ProjectsModel();
                var projectmodel = businessLogic.LoadProject(model.GetProjectsModel(),model.GetScopesList());
                var result = projectsModel.GetProjectElement(projectmodel);
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Code = 0,
                    Message = "Loaded!",
                    Data = new Dictionary<string, object> { { "Result", result }}
                }, "Json");
            }
            catch (TociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Code = ex.GetErrorCode(ex),
                    ErrorMessage = string.Join(", ", ex.GetErrorList(ex)),
                    Message = "Load unsuccessfull."
                }, "Json");
            }
            catch (Exception)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Message = "Load unsuccessfull."
                }, "Json");
            }
        }

        [Route("Load/Projects")]
        [HttpPost]
        public Dictionary<string, object> LoadProjects(BusinessModel model)
        {
            try
            {
                ProjectsModel projectsModel = new ProjectsModel();
                var list = businessLogic.LoadProjects(model.GetScopesList());
                var resultList = projectsModel.GetProjectsList(list);
                return ResultManager.GetApiResult(new SimpleResult { Code = 0, Message = "Loaded!",
                    Data  = new Dictionary<string, object>{ { "Result", resultList}}},"Json");
            }
            catch (TociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Code = ex.GetErrorCode(ex),
                    ErrorMessage = string.Join(", ", ex.GetErrorList(ex)),
                    Message = "Load unsuccessfull."
                }, "Json");
            }
            catch (Exception)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Message = "Load unsuccessfull."
                }, "Json");
            }
        }

        [Route("Delete/Project")]
        [HttpPost]
        public Dictionary<string, object> DeleteProject(BusinessModel model)
        {
            try
            {
                businessLogic.DeleteProject(model.GetProjectsModel(), model.GetScopesList());
                return ResultManager.GetApiResult(new SimpleResult { Code = 0, Message = "Deleted!" }, "Json");
            }
            catch (TociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex),
                ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Delete unsuccessfull." }, "Json");
            }
            catch (Exception)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Message = "Delete unsuccessfull."
                }, "Json");
            }
        }

        [Route("Update/Project")]
        [HttpPost]
        public Dictionary<string,object> UpdateProject(BusinessModel model)
        {
            try
            {

                businessLogic.UpdateProject(model.GetProjectsModel("Update"), model.GetScopesList());
                
                return ResultManager.GetApiResult(new SimpleResult { Code = 0, Message = "Updated!" }, "Json");
            }
            catch (TociApplicationException ex)
            {
                return ResultManager.GetApiResult(new SimpleResult { Code = ex.GetErrorCode(ex),
                ErrorMessage = string.Join(", ", ex.GetErrorList(ex)), Message = "Update unsuccessfull." }, "Json");
            }
            catch (Exception)
            {
                return ResultManager.GetApiResult(new SimpleResult
                {
                    Message = "Update unsuccessfull."
                }, "Json");
            }
        }

    }
}
