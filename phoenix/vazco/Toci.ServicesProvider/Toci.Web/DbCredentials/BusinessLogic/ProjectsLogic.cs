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
                return failure;
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

            var listOfProjects = LoadProjects(listOfModels);
            var project = new Projects();

            foreach (var item in listOfProjects.Where(item => item.projectname.Equals(model.projectname)))
            {
                project = item;
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
                foreach (var project in loadedListOfProjects)
                {  
                    listOfProjects.Add(project);
                }
            }
            return listOfProjects;
        }

        public bool DeleteProject(Projects model, List<Scopes> listOfModels)
        {
            var project = LoadProject(model, listOfModels);
            try
            {
                dbQuery.Delete(project, Projects.PROJECTNAME);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProject(Projects model, List<Scopes> listOfModels)
        {
            var project = LoadProject(model, listOfModels);
            try
            {
                if (project.projectname.Equals(model.projectname))
                {
                    dbQuery.Update(model, Projects.PROJECTNAME);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}