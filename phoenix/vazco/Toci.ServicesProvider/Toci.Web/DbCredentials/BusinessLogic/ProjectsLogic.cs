using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;

namespace DbCredentials.BusinessLogic
{
    public class ProjectsLogic
    {
        private const int notSaved = 0;
        DbQuery dbQuery = new DbQuery();
        ScopesLogic scopesLogic = new ScopesLogic();

        public bool AddProject(Projects model)
        {
            if (IsProjectExist(model))
            {
                throw new ApplicationException("Project exist.");
            }
            try
            {
                return dbQuery.Save(model) != notSaved;
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("Cannot save the project.");
            }
            
        }

        public bool IsProjectExist(Projects model)
        {
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            return list.Any(item => item.projectname.Equals(model.projectname));
        }
        
        public Projects LoadProject(Projects model, List<Scopes> listOfModels)
        {
            if (!IsProjectExist(model))
            {
                throw new Exception("Project does not exist.");
            }
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
            if (!IsProjectExist(model))
            {
                throw new Exception("Project does not exist.");
            }
            
            try
            {
                var project = LoadProject(model, listOfModels);
                dbQuery.Delete(project, Projects.PROJECTNAME);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Cannot delete project.");
            }
        }

        public bool IsProjectExist(Projects model, int projectid)
        {
            var list = dbQuery.Load(model).Cast<Projects>().ToList();
            model.projectid = projectid;
            return list.Any(item => item.projectid.Equals(projectid));
        }
        public bool UpdateProject(Projects model, List<Scopes> listOfModels)
        {
            if (!IsProjectExist(model, model.projectid))
            {
                throw new Exception("Project does not exist.");
            }
            var projectid = model.projectid;
            if (IsProjectExist(model))
            {
                throw new Exception("Invalid project name.");
            }
            model.projectid = projectid;
            try
            {
                
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