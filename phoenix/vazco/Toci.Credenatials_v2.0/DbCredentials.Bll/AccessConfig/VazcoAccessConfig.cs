using Toci.Db.ClusterAccess;
using Toci.Db.DbUtils;

namespace DbCredentials.Bll.AccessConfig
{
    public abstract class VazcoAccessConfig: DataAccessLogic
    {
        protected override DbAccessConfig GetDbAccessConfig()
        {
            return new DbAccessConfig
            {
                DbName = "ImportantStuffDb",
                DbAddress = "localhost",
                Password = "localhost",
                UserName = "postgres",
                ClientKind = SqlClientKind.PostgreSql
            };
        }
    }
}