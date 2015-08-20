using System;
using System.Collections.Generic;
using System.Linq;
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
        DbQuery dbQuery = new DbQuery();
        ScopesLogic scopesLogic = new ScopesLogic();
        BusinessLogicUtills utills = new BusinessLogicUtills();

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
                throw new Exception("There is no valid scopes, for this project.");
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
            throw new Exception("There is no valid scopes.");
        }

        public bool DeleteProject(Projects model, List<Scopes> listOfModels)
        {
            try
            {
                utills.ValidateProjectExsiting(model);
                var project = LoadProject(model, listOfModels);
                return dbQuery.Delete(project, Projects.PROJECTNAME) != notDeleted;
            }
            catch (Exception)
            {
                throw new Exception("Cannot delete project.");
            }
        }

        
        public bool UpdateProject(Projects model, List<Scopes> listOfModels)
        {
            
            try
            {
                utills.ValidateProjectExsitingById(model);
                utills.ValidateProjectNameExsiting(model);
                var project = LoadProject(GetProjectName(model, model.projectid), listOfModels);
                if (project.projectid.Equals(model.projectid))
                {
                    dbQuery.Update(model, Projects.PROJECTID);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Cannot update project.");
            }
        }

        public Projects GetProjectName(Projects model, int projectid)
        {
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            var newmodel = new Projects();
            model.projectid = projectid;
            foreach (var item in list.Where(item => item.projectid.Equals(model.projectid)))
            {
                newmodel.projectname = item.projectname;
            }
            return newmodel;
        }
    }
}