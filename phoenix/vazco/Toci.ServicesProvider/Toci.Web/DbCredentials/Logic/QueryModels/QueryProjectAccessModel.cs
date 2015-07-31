using DbCredentials.Logic.DbModels;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.QueryModels
{
    public class QueryProjectAccessModel: QueryModel
    {
        protected const string tableName = "ProjectAccess";
        protected const string accessIDColumnName = "AccessID";
        protected const string userIDColumnName = "UserID";
        protected const string projectIDColumnName = "ProjectID";

        public QueryProjectAccessModel() : base(tableName)
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

        public override void FillAddInModel(DbModel model)
        {
            var dbModel = (DbProjectAccessModel) model;
            SetAccessID(dbModel.AccessID);
            SetUserID(dbModel.UserID);
            SetProjectID(dbModel.ProjectID);
        }
    }
}