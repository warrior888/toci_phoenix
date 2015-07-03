using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class users_portfolio : Model
    {
        public users_portfolio() : base("users_portfolio")
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
         
        public const string ID_USERS = "id_users";
        public System.Int32 id_users
            {
                get
                {
                     return (System.Int32) Fields[ID_USERS].GetValue();
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string ID_PORTFOLIO = "id_portfolio";
        public System.Int32 id_portfolio
            {
                get
                {
                     return (System.Int32) Fields[ID_PORTFOLIO].GetValue();
                }
                set
                {
                    SetValue(ID_PORTFOLIO, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new users_portfolio();
        }
    }
}
