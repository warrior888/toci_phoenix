using System.Data;

namespace Toci.Db.Interfaces
{
    public interface IDbHandle
    {
        DataSet GetData(IModel model);

        int InsertData(IModel model);
        int UpdateData(IModel model);
        int DeleteData(IModel model);

    }
}
