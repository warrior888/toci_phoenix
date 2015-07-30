using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCrypting
{
    public class AddInModel : Model
    {
        private const string DataColumnName = "data" ;
        private const string TimeColumnName = "addingTime";
        private const string NickColumnName = "name" ;
        private const string HashColumnName = "hash" ;
        private const string Star = "*" ;

        public AddInModel(string tableName) : base(tableName)
        {
        }

        protected override IModel GetInstance()
        {
            throw new System.NotImplementedException();
        }
        public void AddIsWhere<T>(string key, T value, bool isWhere)
        {
            Fields.Add(key, new DbField<object>(key, value, isWhere));
        }

        public void SetData(string data)
        {
            SetValue(DataColumnName, data);
        }

        public void SetTime(DateTime time)
        {
            SetValue(TimeColumnName, time);
        }

        public  void SetNick(string nick)
        {
            SetValue(NickColumnName, nick);
        }
        public void SetHash(string hash)
        {
            SetValue(HashColumnName, hash);
        }
        public void SetGwiazdka()
        {
            SetValue(Star, Star);
        }

    }
}