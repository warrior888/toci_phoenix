using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Utilities.Test.Developers.Kielich
{
    class TestModel : Model
    {
        public const string AGE = "age";
        public const string HEIGHT = "height";
        public const string CITY = "city";

        public TestModel(string tableName) : base(tableName)
        {
        }

        public void AddIsWhere<T>(string key, T value, bool isWhere)
        {
            Fields.Add(key, new DbField<object>(key, value, isWhere));
        }

        public void AddIsWhere<T>(string key, T value, bool isWhere, SelectClause clause)
        {
            Fields.Add(key, new DbField<object>(key, value, isWhere, clause));
        }


        public int Age
        {
            get
            {
                return (int)Fields[AGE].GetValue();
            }
            set
            {
                SetValue(AGE, value);
            }
        }

        public int Height
        {
            get
            {
                return (int)Fields[HEIGHT].GetValue();
            }
            set
            {
                SetValue(HEIGHT, value);
            }
        }

        public string City
        {
            get
            {
                return (string) Fields[CITY].GetValue();            
            }
            set
            {
                SetValue(CITY, value);              
            }
        }

        protected override IModel GetInstance()
        {   //return model obcject
            throw new NotImplementedException();
        }
    }
}