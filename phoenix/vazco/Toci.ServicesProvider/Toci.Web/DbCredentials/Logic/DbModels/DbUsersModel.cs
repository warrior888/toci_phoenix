using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbUsersModel: DbModel
    {
        public int UserID { get; set; }
        public int ScopeID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        
        protected const string tableName = "Users";
        private const string userIDColumnName = "UserID";
        private const string scopeIDColumnName = "ScopeID";
        private const string userLoginColumnName = "UserLogin";
        private const string userPasswordColumnName = "UserPassword";

        public DbUsersModel() : base(tableName)
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

    }
}