using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class results : Model
    {
        public results() : base("results")
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

        public const string EXECUTION_TIME_MS = "execution_time_ms";
        public int ExecutionTimeMs
        {
            get
            {
                return GetValue<int>(EXECUTION_TIME_MS);
            }
            set
            {
                SetValue(EXECUTION_TIME_MS, value);
            }
        }

        public const string HAVE_BEEN_COMPILED = "have_been_compiled";
        public bool HaveBeenCompiled
        {
            get
            {
                return GetValue<bool>(HAVE_BEEN_COMPILED);
            }
            set
            {
                SetValue(HAVE_BEEN_COMPILED, value);
            }
        }

        public const string TIME_SPENT_S = "time_spent_s";
        public int TimeSpendS
        {
            get
            {
                return GetValue<int>(TIME_SPENT_S);
            }
            set
            {
                SetValue(TIME_SPENT_S, value);
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

        public const string ID_TASKS = "id_tasks";
        public int IdTasks
        {
            get
            {
                return GetValue<int>(ID_TASKS);
            }
            set
            {
                SetValue(ID_TASKS, value);
            }
        }

        public const string ID_UNIT_TESTS = "id_unit_tests";
        public int IdUnitTests
        {
            get
            {
                return GetValue<int>(ID_UNIT_TESTS);
            }
            set
            {
                SetValue(ID_UNIT_TESTS, value);
            }
        }




        protected override IModel GetInstance()
        {
            return new results();
        }
    }
}