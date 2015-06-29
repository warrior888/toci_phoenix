using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace _3mb.Dal.User
{
    public class Users : Model
    {
        public Users() : base("users")
        {
        }
         
        public const string NAME = "name";
        public System.String name
            {
                get
                {
                     return (System.String) Fields[NAME].GetValue();
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
         
        public const string EMAIL = "email";
        public System.String email
            {
                get
                {
                     return (System.String) Fields[EMAIL].GetValue();
                }
                set
                {
                    SetValue(EMAIL, value);
                }
            }
         
        public const string CELL_PHONE = "cell_phone";
        public System.String cell_phone
            {
                get
                {
                     return (System.String) Fields[CELL_PHONE].GetValue();
                }
                set
                {
                    SetValue(CELL_PHONE, value);
                }
            }

        protected override IModel GetInstance()
        {
            return new Users();
        }
    }
}
