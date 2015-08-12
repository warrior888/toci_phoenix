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
         
        public const string ID_USERS = "id_users";
        public System.Int32 IdUsers
            {
                get
                {
                     return GetValue<System.Int32>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string ID_PORTFOLIO = "id_portfolio";
        public System.Int32 IdPortfolio
            {
                get
                {
                     return GetValue<System.Int32>(ID_PORTFOLIO);
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
