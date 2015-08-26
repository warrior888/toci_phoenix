using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class users : Model
    {
        public users() : base("users")
        {
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
         
        public const string SUERNAME = "suername";
        public string Suername
            {
                get
                {
                     return GetValue<string>(SUERNAME);
                }
                set
                {
                    SetValue(SUERNAME, value);
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
         
        public const string PHONE = "phone";
        public string Phone
            {
                get
                {
                     return GetValue<string>(PHONE);
                }
                set
                {
                    SetValue(PHONE, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new users();
        }
    }
}
