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
        public int Id
            {
                get
                {
                     return GetValue<int>(ID);
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string ID_ROLES = "id_roles";
        public int IdRoles
            {
                get
                {
                     return GetValue<int>(ID_ROLES);
                }
                set
                {
                    SetValue(ID_ROLES, value);
                }
            }
         
        public const string LOGIN = "login";
        public string Login
            {
                get
                {
                     return GetValue<string>(LOGIN);
                }
                set
                {
                    SetValue(LOGIN, value);
                }
            }
         
        public const string PASSWORD = "password";
        public string Password
            {
                get
                {
                     return GetValue<string>(PASSWORD);
                }
                set
                {
                    SetValue(PASSWORD, value);
                }
            }
         
        public const string EMAIL = "email";
        public string Email
            {
                get
                {
                     return GetValue<string>(EMAIL);
                }
                set
                {
                    SetValue(EMAIL, value);
                }
            }
         
        public const string NICK = "nick";
        public string Nick
            {
                get
                {
                     return GetValue<string>(NICK);
                }
                set
                {
                    SetValue(NICK, value);
                }
            }
         
        public const string NAME = "name";
        public string Name
            {
                get
                {
                     return GetValue<string>(NAME);
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
         
        public const string SURNAME = "surname";
        public string Surname
            {
                get
                {
                     return GetValue<string>(SURNAME);
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
