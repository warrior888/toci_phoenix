using System.Collections.Generic;
using System.Data;
using System.Linq;
using Toci.Db.Interfaces;

namespace Toci.Db.DbVirtualization
{
    public abstract class Model : IModel
    {
        public const string ID = "id";

        protected Dictionary<string, IDbField<object>> Fields = new Dictionary<string, IDbField<object>>();
        protected string TableName;

        protected Model(string tableName)
        {
            this.TableName = tableName;
        }
        public Dictionary<string, IDbField<object>> GetFields()
        {
            return Fields;
        }

        public IDbField<object> GetField(string columnName)
        {
            return Fields.ContainsKey(columnName) ? Fields[columnName] : null;
        }

        public string GetTableName()
        {
            return TableName;
        }

        public int Id
        {
            get
            {
                return (int) Fields[ID].GetValue();
            }
            set
            {
                SetValue(ID, value);
            }
        }

        protected void SetValue<T>(string key, T value)
        {
            if (Fields.ContainsKey(key))
            {
                Fields[key].SetValue(value);
            }
            else
            {
                Fields.Add(key, new DbField<object>(key, value));
            }
        }

        protected T GetValue<T>(string key)
        {
            if (Fields.ContainsKey(key))
            {
                return (T)Fields[key].GetValue();
            }

            return default(T);
        }

        protected void SetValue<T>(Model model, string key, T value)
        {
            if (model.Fields.ContainsKey(key))
            {
                model.Fields[key].SetValue(value);
            }
            else
            {
                model.Fields.Add(key, new DbField<object>(key, value));
            }
        }

        public void SetWhere(string columnName)
        {
            if (Fields.ContainsKey(columnName))
            {
                Fields[columnName].SetWhere(true);
            }
        }
        public void SetPrimaryKey(string columnName)
        {
            if (Fields.ContainsKey(columnName))
            {
                Fields[columnName].SetPrimary(true);
            }
        }

        public IModel SetSelect(string columnName, SelectClause clause)
        {
            if (Fields.ContainsKey(columnName))
            {
                Fields[columnName].SetWhere(true);
                Fields[columnName].SetSelectClause(clause);
            }
            return this;
        }

        public IModel SetSelect<T>(string columnName, SelectClause clause, T value)
        {
            SetValue(columnName, value);
            return SetSelect(columnName, clause);
        }

        public List<IModel> GetDataRowsList(DataSet table)
        {

           return table.Tables[0].Rows.OfType<DataRow>().Select(item => GetDataRow(item, table.Tables[0].Columns)).ToList();

        }

        protected virtual IModel GetDataRow(DataRow row, DataColumnCollection columns)
        {
            var _model = GetInstance();
            
            foreach (DataColumn column in columns)
            {
                SetValue((Model)_model, column.ColumnName, row[column.ColumnName]);
            }

            return _model;
        }

        protected abstract IModel GetInstance();

        //(ID, bool iswhere)
        //(ID, SelectClause clasue)
    }
}
