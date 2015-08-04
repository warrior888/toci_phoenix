using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.CredentialsModels
{
    public class Users : Model
    {
        public Users() : base("Users")
        {
        }
         
        public const string USERID = "UserID";
        public System.Int32 UserID
            {
                get
                {
                     return (System.Int32) Fields[USERID].GetValue();
                }
                set
                {
                    SetValue(USERID, value);
                }
            }
         
        public const string SCOPEID = "ScopeID";
        public System.Int32 ScopeID
            {
                get
                {
                     return (System.Int32) Fields[SCOPEID].GetValue();
                }
                set
                {
                    SetValue(SCOPEID, value);
                }
            }
         
        public const string USERLOGIN = "UserLogin";
        public System.String UserLogin
            {
                get
                {
                     return (System.String) Fields[USERLOGIN].GetValue();
                }
                set
                {
                    SetValue(USERLOGIN, value);
                }
            }
         
        public const string USERPASSWORD = "UserPassword";
        public System.String UserPassword
            {
                get
                {
                     return (System.String) Fields[USERPASSWORD].GetValue();
                }
                set
                {
                    SetValue(USERPASSWORD, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new Users();
        }
    }
}
