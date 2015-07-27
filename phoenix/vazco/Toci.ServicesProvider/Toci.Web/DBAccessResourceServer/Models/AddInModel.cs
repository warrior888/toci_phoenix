using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DBAccessResourceServer.Models
{
    public class AddInModel : Model
    {
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
            SetValue("data", data);
        }

        public void SetTime(DateTime time)
        {
            SetValue("addingTime", time);
        }

        public  void SetNick(string nick)
        {
            SetValue("name", nick);
        }
        public void SetGwiazdka()
        {
            SetValue("*", "*");
        }

    }
}