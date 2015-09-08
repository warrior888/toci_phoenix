using DbCredentials.Bll.Interfaces.BusinessLogic;
using DbCredentials.Bll.Interfaces.BusinessModels;
using Toci.Db.ClusterAccess;
using Toci.Db.DbUtils;

namespace DbCredentials.Bll.BusinessLogic
{
    public class ProjectModelLogic : DataAccessLogic, IProjectModelLogic
    {
        
        private static DbAccessConfig DatabaseAccess()
        {
            return new DbAccessConfig
            {
                Password = "localhost",
                DbAddress = "localhost",
                DbName = "ImportatStuffDb",
                UserName = "postgres"
            };
        }


    }
}