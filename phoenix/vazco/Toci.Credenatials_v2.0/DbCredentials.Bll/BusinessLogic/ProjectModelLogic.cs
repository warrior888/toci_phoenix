using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.Bll.AccessConfig;
using DbCredentials.Bll.BusinessModel;
using DbCredentials.Bll.Interfaces.BusinessLogic;
using DbCredentials.Bll.Interfaces.BusinessModels;
using DbCredentials.Dal.GeneratedModels;

using Toci.Db.DbVirtualization;

namespace DbCredentials.Bll.BusinessLogic
{
    public class ProjectModelLogic : VazcoAccessConfig, IProjectModelLogic
    {
        private ScopeModelLogic scopeLogic = new ScopeModelLogic();

        public int InsertProjectModel(Projects model)
        {
            scopeLogic.InsertScopeModel(new Scopes {ScopeId = model.ScopeId});
            return IsProjectNameExist(model.ProjectName) ? InsertModel(model) : 0;
        }

        public bool IsProjectNameExist(string projectName)
        {
            return GetAllElements<IProjectModel, Projects>().Any(item => projectName.Equals(item.ProjectName));
        }

        public IProjectModel GetProjectModelByProjectName(ProjectModel model, List<Scopes> scopesList)
        {
            scopeLogic.AddScopeModelList(scopesList);
            var project =
                    GetElementsByColumnValue<IProjectModel, Projects, int>(Projects.SCOPEID, SelectClause.Equal,
                        model.Scope.ScopeId)[0];
            if (scopesList.Any(scope => project.Scope.ScopeId == scope.ScopeId))
            {
                return project;
            }
            throw new Exception();
        }

//        public IProjectModel GetProjectModelByScopeList(Projects model, List<Scopes> scopesList)
//        {
//
//        }
    }
}