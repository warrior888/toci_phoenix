using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbScopesModel: DbModel
    {
        public int ScopeID { get; set; }
        public string ScopeName { get; set; }

        protected const string tableName = "Scopes";
        protected const int scopeIdPosition = 0;
        protected const int scopeNamePosition = 1;


        public DbScopesModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }


        public override DbModel FillPropertis(object[] item)
        {
            return new DbScopesModel
            {
                ScopeID = (int)item[scopeIdPosition],
                ScopeName = (string)item[scopeNamePosition]
            };
        }
    }
}