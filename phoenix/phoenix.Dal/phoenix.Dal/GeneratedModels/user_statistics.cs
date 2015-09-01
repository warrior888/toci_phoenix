using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace UnitTestProject.res
{
    public class user_statistics : Model
    {
        public user_statistics() : base("user_statistics")
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

        public const string TOTAL_TIME_SPENT_S = "total_time_spent_s";
        public int TotalTimeSpentS
        {
            get
            {
                return GetValue<int>(TOTAL_TIME_SPENT_S);
            }
            set
            {
                SetValue(TOTAL_TIME_SPENT_S, value);
            }
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

        protected override IModel GetInstance()
        {
            return new user_statistics();
        }
    }
}