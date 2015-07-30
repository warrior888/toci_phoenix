using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbUsersModel: Model
    {
        public int UserID { get; set; }
        public int ScopeID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        private const string star = "*";
        protected const string tableName = "Users";

        public DbUsersModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}