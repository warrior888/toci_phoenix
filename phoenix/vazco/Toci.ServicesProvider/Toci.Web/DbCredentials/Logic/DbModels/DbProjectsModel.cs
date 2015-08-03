using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbProjectsModel: DbModel
    {
        public int ProjectID { get; set; }
        public int ScopeID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectData { get; set; }

        protected const string tableName = "Projects";
        protected const int projectIdPosition = 0;
        protected const int scopeIdPosition = 1;
        protected const int projectNamePosition = 2;
        protected const int projectDataPosition = 3;


        public DbProjectsModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }

        public override DbModel FillPropertis(object[] item)
        {
            return new DbProjectsModel
            {
                ProjectID = (int) item[projectIdPosition],
                ScopeID = (int) item[scopeIdPosition],
                ProjectName = (string) item[projectNamePosition],
                ProjectData = (string) item[projectDataPosition]
            };
        }
    }
}