using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class users_portfolio : Model
    {
        public users_portfolio() : base("users_portfolio")
        {
        }
         
         
        public const string ID_USERS = "id_users";
        public int IdUsers
            {
                get
                {
                     return GetValue<int>(ID_USERS);
                }
                set
                {
                    SetValue(ID_USERS, value);
                }
            }
         
        public const string ID_PORTFOLIO = "id_portfolio";
        public int IdPortfolio
            {
                get
                {
                     return GetValue<int>(ID_PORTFOLIO);
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
