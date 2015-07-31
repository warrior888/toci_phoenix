using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbScopesModel: DbModel
    {
        public int ScopeID { get; set; }
        public string ScopeName { get; set; }

        protected const string tableName = "Scopes";
        private const string scopeIDColumnName = "ScopeID";
        private const string scopeNameColumnName = "ScopeName";


        public DbScopesModel(string tableName) : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }
        public void SetScopeID(int scopeID)
        {
            SetValue(scopeIDColumnName, scopeID);
        }

        public void SetScopeName(string scopeName)
        {
            SetValue(scopeNameColumnName, scopeName);
        }

    }
}