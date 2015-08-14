using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using Toci.Db.Interfaces;

namespace DbCredentials.BusinessLogic
{
    public class ProjectsLogic
    {
        private const int notSaved = 0;
        private const bool failure = false;
        DbQuery dbQuery = new DbQuery();
        ScopesLogic scopesLogic = new ScopesLogic();

        public bool AddProject(Projects model)
        {
            if (IsProjectExist(model))
            {
                throw new Exception("Project exist");
            }
            return dbQuery.Save(model) != notSaved;
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
                throw new Exception("Project does not exist. ");
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
                throw new Exception("Project does not exist. ");
            }
            
            try
            {
                var project = LoadProject(model, listOfModels);
                dbQuery.Delete(project, Projects.PROJECTNAME);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete project. " + ex.Message);
            }
        }

        public bool UpdateProject(Projects model, List<Scopes> listOfModels)
        {
            if (!IsProjectExist(model))
            {
                throw new Exception("Project does not exist. ");
            }
            try
            {
                var project = LoadProject(model, listOfModels);
                if (project.projectname.Equals(model.projectname))
                {
                    dbQuery.Update(model, Projects.PROJECTNAME);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update project. " + ex.Message);
            }
        }
    }
}