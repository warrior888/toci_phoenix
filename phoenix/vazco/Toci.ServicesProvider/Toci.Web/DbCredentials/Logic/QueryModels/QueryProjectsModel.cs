using DbCredentials.Logic.DbModels;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.QueryModels
{
    public class QueryProjectsModel: QueryModel
    {
        protected const string tableName = "Projects";
        private const string projectIDColumnName = "ProjectID";
        private const string scopeIDColumnName = "ScopeID";
        private const string projectNameColumnName = "ProjectName";
        private const string projectDataColumnName = "ProjectData";

        public QueryProjectsModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }

        public void SetProjectID(int projectID)
        {
            SetValue(projectIDColumnName, projectID);
        }

        public void SetScopeID(int scopeID)
        {
            SetValue(scopeIDColumnName, scopeID);
        }

        public void SetProjectName(string projectName)
        {
            SetValue(projectNameColumnName, projectName);
        }

        public void SetProjectData(string projectData)
        {
            SetValue(projectDataColumnName, projectData);
        }

        public override void FillAddInModel(DbModel model)
        {
            var dbModel = (DbProjectsModel) model;
            SetProjectID(dbModel.ProjectID);
            SetScopeID(dbModel.ScopeID);
            SetProjectName(dbModel.ProjectName);
            SetProjectData(dbModel.ProjectData);
        }
    }
}