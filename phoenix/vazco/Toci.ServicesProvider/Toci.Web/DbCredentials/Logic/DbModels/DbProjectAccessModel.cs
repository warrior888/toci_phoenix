using DbCredentials.Config;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbProjectAccessModel: DbModel
    {
        public int AccessID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }

        protected const string tableName = "ProjectAccess";
        private const string accessIDColumnName = "AccessID";
        private const string userIDColumnName = "UserID";
        private const string projectIDColumnName = "ProjectID";

        public DbProjectAccessModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }

        public void SetAccessID(int accessID)
        {
            SetValue(accessIDColumnName, accessID);
        }

        public void SetUserID(int userID)
        {
            SetValue(userIDColumnName, userID);
        }

        public void SetProjectID(int projectID)
        {
            SetValue(projectIDColumnName, projectID);
        }

        
    }
}