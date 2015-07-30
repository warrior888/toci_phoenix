using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbProjectsModel: Model
    {
        public int ProjectID { get; set; }
        public int ScopeID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectData { get; set; }
        private const string star = "*";
        protected const string tableName = "Projects";

        public DbProjectsModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}