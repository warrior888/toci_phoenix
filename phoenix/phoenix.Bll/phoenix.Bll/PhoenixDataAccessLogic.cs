using Toci.Db.ClusterAccess;
using Toci.Db.DbUtils;

namespace Phoenix.Bll
{
    public abstract class PhoenixDataAccessLogic : DataAccessLogic
    {
        protected override DbAccessConfig GetDbAccessConfig()
        {
            return new DbAccessConfig
            {
                UserName = "",
                Password = "",
                DbAddress = "",
                DbName = "",
            };
        }
    }
}