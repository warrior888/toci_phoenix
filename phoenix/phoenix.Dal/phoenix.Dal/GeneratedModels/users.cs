using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class users : Model
    {
        public users() : base("users")
        {
        }
         
        public const string ID = "id";
        public System.Int32 id
            {
                get
                {
                     return (System.Int32) Fields[ID].GetValue();
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string ID_ROLES = "id_roles";
        public System.Int32 id_roles
            {
                get
                {
                     return (System.Int32) Fields[ID_ROLES].GetValue();
                }
                set
                {
                    SetValue(ID_ROLES, value);
                }
            }
         
        public const string LOGIN = "login";
        public System.String login
            {
                get
                {
                     return (System.String) Fields[LOGIN].GetValue();
                }
                set
                {
                    SetValue(LOGIN, value);
                }
            }
         
        public const string PASSWORD = "password";
        public System.String password
            {
                get
                {
                     return (System.String) Fields[PASSWORD].GetValue();
                }
                set
                {
                    SetValue(PASSWORD, value);
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
         
        public const string NICK = "nick";
        public System.String nick
            {
                get
                {
                     return (System.String) Fields[NICK].GetValue();
                }
                set
                {
                    SetValue(NICK, value);
                }
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
         
        public const string SURNAME = "surname";
        public System.String surname
            {
                get
                {
                     return (System.String) Fields[SURNAME].GetValue();
                }
                set
                {
                    SetValue(SURNAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new users();
        }
    }
}
