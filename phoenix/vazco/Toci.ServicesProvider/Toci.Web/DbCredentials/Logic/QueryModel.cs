using Toci.Db.DbVirtualization;

namespace DbCredentials.Logic
{
    public abstract class QueryModel: Model
    {
        protected QueryModel(string tableName): base(tableName)
        {
        }

        protected const string star = "*";

        public void SetAll()
        {
            SetValue(star, star);
        }

        public void AddIsWhere<T>(string key, T value, bool isWhere)
        {
            Fields.Add(key, new DbField<object>(key, value, isWhere));
        }
        public abstract void FillAddInModel(DbModel model);
    }
}