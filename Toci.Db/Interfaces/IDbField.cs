using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.DbVirtualization;

namespace Toci.Db.Interfaces
{
    public interface IDbField<T>
    {
        string GetColumnName();
        T GetValue();
        bool IsWhere();
        bool IsPrimaryKey();
        SelectClause GetSelectClause();
        void SetValue(T value);
        void SetWhere(bool isWhere);
        void SetPrimary(bool isPrimary);
        void SetSelectClause(SelectClause clause);
    }
}
