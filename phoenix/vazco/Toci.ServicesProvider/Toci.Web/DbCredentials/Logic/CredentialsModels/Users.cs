using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace DbCredentials.CredentialsModels
{
    public class Users : Model
    {
        public Users() : base("Users")
        {
        }
         
        public const string USERID = "userid";
        public System.Int32 userid
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
         
        public const string SCOPEID = "scopeid";
        public System.Int32 scopeid
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
         
        public const string USERLOGIN = "userlogin";
        public System.String userlogin
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
         
        public const string USERPASSWORD = "userpassword";
        public System.String userpassword
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
