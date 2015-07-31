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
        protected const int userIdPosition = 0;
        protected const int scopeIdPosition = 1;
        protected const int userLoginPosition = 2;
        protected const int userPasswordPosition = 3;

        public DbUsersModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }

        public override DbModel FillPropertis(object[] item)
        {
            return new DbUsersModel
            {
                UserID = (int) item[userIdPosition],
                ScopeID = (int) item[scopeIdPosition],
                UserLogin = (string) item[userLoginPosition],
                UserPassword = (string) item[userPasswordPosition]
            };
        }
    }
}