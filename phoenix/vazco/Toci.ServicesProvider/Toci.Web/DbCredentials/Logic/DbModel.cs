using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.Logic
{
    public abstract class DbModel: Model
    {
        protected const string star = "*";

        protected DbModel(string tableName) : base(tableName)
        {
        }

        public void SetAll()
        {
            SetValue(star, star);
        }
    }

}