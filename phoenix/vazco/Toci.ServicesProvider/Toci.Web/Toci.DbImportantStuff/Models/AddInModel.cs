using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DBAccessResourceServer.Models
{
    public class AddInModel : Model
    {
        private const string DataTableName = "data" ;
        private const string TimeTableName = "addingTime";
        private const string NickTableName = "name" ;
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
            SetValue(DataTableName, data);
        }

        public void SetTime(DateTime time)
        {
            SetValue(TimeTableName, time);
        }

        public  void SetNick(string nick)
        {
            SetValue(NickTableName, nick);
        }
        public void SetGwiazdka()
        {
            SetValue(Star, Star);
        }

    }
}