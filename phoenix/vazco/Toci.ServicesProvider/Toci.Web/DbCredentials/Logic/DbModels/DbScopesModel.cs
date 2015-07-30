using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbScopesModel: Model
    {
        public int ScopeID { get; set; }
        public string ScopeName { get; set; }
        private const string star = "*";
        protected const string tableName = "Scopes";

        public DbScopesModel(string tableName) : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}