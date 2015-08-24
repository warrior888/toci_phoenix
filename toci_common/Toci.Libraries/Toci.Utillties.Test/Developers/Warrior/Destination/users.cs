using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Toci.Utilities.Test.Developers.Warrior.Destination
{
    public class users : Model
    {
        public users() : base("users")
        {
        }
        
        public String id
            {
                get
                {
                     return (String) Fields[ID].GetValue();
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string NAME = "name";
        public String name
            {
                get
                {
                     return (String) Fields[NAME].GetValue();
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
         
        public const string EMAIL = "email";
        public String email
            {
                get
                {
                     return (String) Fields[EMAIL].GetValue();
                }
                set
                {
                    SetValue(EMAIL, value);
                }
            }
         
        public const string CELL_PHONE = "cell_phone";
        public String cell_phone
            {
                get
                {
                     return (String) Fields[CELL_PHONE].GetValue();
                }
                set
                {
                    SetValue(CELL_PHONE, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new users();
        }
    }
}
