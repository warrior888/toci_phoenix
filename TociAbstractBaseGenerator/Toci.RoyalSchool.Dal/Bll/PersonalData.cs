using Toci.Db.ClusterAccess;
using Toci.Db.Interfaces;

namespace Toci.RoyalSchool.Dal.Bll
{
    public class PersonalDataBll
    {
        protected readonly IDbHandle DbHandle = DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, "", "", "", "");

        public bool SaveClient(PersonalData data)
        {
            return DbHandle.InsertData(data) > 0;
        }
    }
}