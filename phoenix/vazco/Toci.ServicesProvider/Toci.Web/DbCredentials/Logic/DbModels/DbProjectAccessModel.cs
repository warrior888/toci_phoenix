using System.Collections.Generic;
using DbCredentials.Config;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic.DbModels
{
    public class DbProjectAccessModel: DbModel
    {
        public int AccessID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }

        protected const string tableName = "ProjectAccess";
        protected const int accessIdPosition = 0;
        protected const int userIdPosition = 1;
        protected const int projectIdPosition = 2;
        

        public DbProjectAccessModel(): base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            return this;
        }

        public override DbModel FillPropertis(object[] item)
        {
            return new DbProjectAccessModel 
            {
                AccessID = (int) item[accessIdPosition], 
                UserID = (int)item[userIdPosition], 
                ProjectID = (int)item[projectIdPosition]
            };
        }
    }
}