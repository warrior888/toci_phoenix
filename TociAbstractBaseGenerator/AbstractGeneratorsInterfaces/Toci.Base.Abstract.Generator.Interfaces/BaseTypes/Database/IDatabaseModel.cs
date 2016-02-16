using System.Collections.Generic;
using System.Data;

namespace Toci.Base.Abstract.Generator.Interfaces.BaseTypes.Database
{
    public interface IDatabaseModel
    {
        Dictionary<string, IDbField<object>> GetFields();
        IDbField<object> GetField(string columnName);
        string GetTableName();
        void SetWhere(string columnName);
        List<IDatabaseModel> GetDataRowsList(DataSet table);
    }
}