using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Utilities.Test.Developers.Casanova
{
    class TestModel : Model
    {
        public TestModel(string tableName) : base(tableName)
        {

        }

        public void AddIsWhere<T>(string key, T value, bool isWhere)
        {
            Fields.Add(key, new DbField<object>(key, value, isWhere));
        }

        public void setAge(int age)
        {
            SetValue("wiek", age);
        }

        public void setName(string name)
        {
            SetValue("imie", name);
        }

        public void setSurname(string surname)
        {
            SetValue("nazwisko", surname);
        }

        protected override IModel GetInstance()
        {   //return model obcject
            throw new NotImplementedException();
        }
    }
}
