using DbCredentials.Logic.DbModels;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.QueryModels
{
    public class QueryScopesModel: QueryModel
    {
        protected const string tableName = "Scopes";
        private const string scopeIDColumnName = "ScopeID";
        private const string scopeNameColumnName = "ScopeName";
        
        public QueryScopesModel() : base(tableName)
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

        public override void FillAddInModel(DbModel model)
        {
            var dbModel = (DbScopesModel)model;
            SetScopeID(dbModel.ScopeID);
            SetScopeName(dbModel.ScopeName);
        }
    }
}