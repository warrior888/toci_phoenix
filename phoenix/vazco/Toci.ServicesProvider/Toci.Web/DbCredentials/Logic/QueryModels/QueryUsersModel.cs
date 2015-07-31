using DbCredentials.Logic.DbModels;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.QueryModels
{
    public class QueryUsersModel: QueryModel
    {
        protected const string tableName = "Users";
        protected const string userIDColumnName = "UserID";
        protected const string scopeIDColumnName = "ScopeID";
        protected const string userLoginColumnName = "UserLogin";
        protected const string userPasswordColumnName = "UserPassword";

        public QueryUsersModel(): base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }

        public void SetUserID(int userID)
        {
            SetValue(userIDColumnName, userID);
        }

        public void SetScopeID(int scopeID)
        {
            SetValue(scopeIDColumnName, scopeID);
        }

        public void SetUserLogin(string userLogin)
        {
            SetValue(userLoginColumnName, userLogin);
        }

        public void SetUserPassword(string userPassword)
        {
            SetValue(userPasswordColumnName, userPassword);
        }

        public override void FillAddInModel(DbModel model)
        {
            var dbModel = (DbUsersModel)model;
            SetUserID(dbModel.UserID);
            SetScopeID(dbModel.ScopeID);
            SetUserLogin(dbModel.UserLogin);
            SetUserPassword(dbModel.UserPassword);
        }
    }
}