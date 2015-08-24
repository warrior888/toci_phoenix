using System.Collections.Generic;
using System.Linq;
using DbCredentials.Config;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.ErrorsAndMessages.Exceptions;
using Toci.Utilities.Common.Exceptions;

namespace DbCredentials.BusinessLogic
{
    public class ProjectsLogic
    {
        private const int notSaved = 0;
        private const int notDeleted = 0;
        readonly DbQuery dbQuery;
        readonly ScopesLogic scopesLogic;
        readonly BusinessLogicUtills utills;

        public ProjectsLogic(DbConfig dbConfig)
        {
            dbQuery = new DbQuery(dbConfig);
            scopesLogic = new ScopesLogic(dbConfig);
            utills = new BusinessLogicUtills(dbConfig);
        }

        public bool AddProject(Projects model)
        {
            try
            {
                utills.ValidateProjectNameExsiting(model);
                return dbQuery.Save(model) != notSaved;
            }
            catch (TociApplicationException ex)
            {
                throw new WebApiTociApplicationException("Cannot save the project.", null, (int)ApiErrors.WrongData, ex);
            }
        }
        
        public Projects LoadProject(Projects model, List<Scopes> listOfModels)
        {
            utills.ValidateProjectExsiting(model);

            var listOfProjects = LoadProjects(listOfModels);
            var project = new Projects();
            var error= true;

            foreach (var item in listOfProjects.Where(item => item.projectname.Equals(model.projectname)))
            {
                error = false;
                project = item;
            }
            if (error)
            {
                throw new WebApiTociApplicationException("There is no valid scopes, for this project.", null, (int)ApiErrors.DataMissing);
            }
            return project;
        }

        public List<Projects> LoadProjects(List<Scopes> listOfScopes)
        {
            var listOfScopesId = scopesLogic.GetScopesId(listOfScopes);
            var listOfProjects = new List<Projects>();

            foreach (var item in listOfScopesId)
            {
                var projectModel = new Projects { scopeid = item.scopeid };
                var loadedListOfProjects = dbQuery.Load(projectModel, Projects.SCOPEID).Cast<Projects>().ToList();
                listOfProjects.AddRange(loadedListOfProjects);
            }
            if (listOfProjects.Any())
            {
                return listOfProjects;
            }
            throw new WebApiTociApplicationException("There is no valid scopes.", null, (int)ApiErrors.DataMissing);
        }

        public bool DeleteProject(Projects model, List<Scopes> listOfModels)
        {
            try
            {
                utills.ValidateProjectExsiting(model);
                var project = LoadProject(model, listOfModels);
                return dbQuery.Delete(project, Projects.PROJECTNAME) != notDeleted;
            }
            catch (TociApplicationException ex)
            {
                throw new WebApiTociApplicationException("Cannot delete project.", null, (int)ApiErrors.WrongData, ex);
            }
        }

        
        public bool UpdateProject(Projects model, List<Scopes> listOfModels)
        {
            try
            {
                utills.ValidateProjectExsitingById(model);
                utills.ValidateProjectNameExsiting(model);
                var project = LoadProject(utills.GetProjectName(model, model.projectid), listOfModels);
                if (!project.projectid.Equals(model.projectid)) return false;
                dbQuery.Update(model, Projects.PROJECTID);
                return true;
            }
            catch (TociApplicationException ex)
            {
                throw new WebApiTociApplicationException("Cannot update project.", null, (int)ApiErrors.WrongData, ex);
            }
        }
    }
}