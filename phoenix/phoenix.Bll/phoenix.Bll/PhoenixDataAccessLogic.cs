using Toci.Db.ClusterAccess;
using Toci.Db.DbUtils;

namespace Phoenix.Bll
{
    public abstract class PhoenixDataAccessLogic : DataAccessLogic
    {
        protected override DbAccessConfig GetDbAccessConfig()
        {
            return new DbHandleAccessDataFactory().Create("Patryk");
            //DbHandleAccessData accessData = new DbHandleAccessDataFactory().Create("Terry");
        }
    }
}