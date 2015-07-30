using DbCredentials.Config;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbProjectAccessModel: Model
    {
        public int AccessID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        private const string star = "*";
        protected const string tableName = "ProjectAccess";

        public DbProjectAccessModel() : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}