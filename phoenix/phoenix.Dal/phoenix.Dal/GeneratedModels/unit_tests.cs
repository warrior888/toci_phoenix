using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class unit_tests : Model
    {
        public unit_tests() : base("unit_tests")
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
         
        public const string UNIT_TEST_CONTENT = "unit_test_content";
        public string UnitTestContent
            {
                get
                {
                     return GetValue<string>(UNIT_TEST_CONTENT);
                }
                set
                {
                    SetValue(UNIT_TEST_CONTENT, value);
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
        

        protected override IModel GetInstance()
        {
            return new unit_tests();
        }
    }
}
