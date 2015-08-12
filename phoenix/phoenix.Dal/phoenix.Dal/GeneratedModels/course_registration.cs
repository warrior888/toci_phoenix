using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class course_registration : Model
    {
        public course_registration() : base("course_registration")
        {
        }
         
        public const string ID = "id";
        public System.Int32 Id
            {
                get
                {
                     return GetValue<System.Int32>(ID);
                }
                set
                {
                    SetValue(ID, value);
                }
            }
         
        public const string ID_ROLES = "id_roles";
        public System.Int32 IdRoles
            {
                get
                {
                     return GetValue<System.Int32>(ID_ROLES);
                }
                set
                {
                    SetValue(ID_ROLES, value);
                }
            }
         
        public const string LOGIN = "login";
        public System.String Login
            {
                get
                {
                     return GetValue<System.String>(LOGIN);
                }
                set
                {
                    SetValue(LOGIN, value);
                }
            }
         
        public const string PASSWORD = "password";
        public System.String Password
            {
                get
                {
                     return GetValue<System.String>(PASSWORD);
                }
                set
                {
                    SetValue(PASSWORD, value);
                }
            }
         
        public const string EMAIL = "email";
        public System.String Email
            {
                get
                {
                     return GetValue<System.String>(EMAIL);
                }
                set
                {
                    SetValue(EMAIL, value);
                }
            }
         
        public const string NICK = "nick";
        public System.String Nick
            {
                get
                {
                     return GetValue<System.String>(NICK);
                }
                set
                {
                    SetValue(NICK, value);
                }
            }
         
        public const string NAME = "name";
        public System.String Name
            {
                get
                {
                     return GetValue<System.String>(NAME);
                }
                set
                {
                    SetValue(NAME, value);
                }
            }
         
        public const string SURNAME = "surname";
        public System.String Surname
            {
                get
                {
                     return GetValue<System.String>(SURNAME);
                }
                set
                {
                    SetValue(SURNAME, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new course_registration();
        }
    }
}
