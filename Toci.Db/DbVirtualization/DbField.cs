using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization
{
    public class DbField<T> : IDbField<T>
    {
        protected string ColumnName;
        protected T FieldValue;
        protected bool FieldIsWhere;
        protected SelectClause Clause;

        public DbField(string columnName)
        {
            this.ColumnName = columnName;
        }
        public DbField(string columnName, T value)
        {
            this.ColumnName = columnName;
            this.FieldValue = value;
        }
        public DbField(string columnName, T value, bool isWhere)
        {
            this.ColumnName = columnName;
            this.FieldValue = value;
            this.FieldIsWhere = isWhere;
        }
        public DbField(string columnName, T value, bool isWhere, SelectClause clause)
        {
            this.ColumnName = columnName;
            this.FieldValue = value;
            this.FieldIsWhere = isWhere;
            this.Clause = clause;
        }
        


        public string GetColumnName()
        {
            return ColumnName;
        }

        public T GetValue()
        {
            return FieldValue;
        }

        public bool IsWhere()
        {
            return FieldIsWhere;
        }

        public SelectClause GetSelectClause()
        {
            return Clause;
        }

        public void SetValue(T value)
        {
            FieldValue = value;
        }

        public void SetWhere(bool isWhere)
        {
            FieldIsWhere = isWhere;
        }

        public void SetSelectClause(SelectClause clause)
        {
            this.Clause = clause;
        }
    }
}
