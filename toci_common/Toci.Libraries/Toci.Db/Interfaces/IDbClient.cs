using System.Data;

namespace Toci.Db.Interfaces
{
    public interface IDbClient
    {
        DataSet GetData(string query);

        int SetData(string query);
    }
}
