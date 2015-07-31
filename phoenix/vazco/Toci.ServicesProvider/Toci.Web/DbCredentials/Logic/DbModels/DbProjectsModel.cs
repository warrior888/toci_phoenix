using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbProjectsModel: DbModel
    {
        public int ProjectID { get; set; }
        public int ScopeID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectData { get; set; }
        
        protected const string tableName = "Projects";
        private const string projectIDColumnName = "ProjectID";
        private const string scopeIDColumnName = "ScopeID";
        private const string projectNameColumnName = "ProjectName";
        private const string projectDataColumnName = "ProjectData";


        public DbProjectsModel() : base(tableName)
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

    }
}