using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class tasks_requirements : Model
    {
        public tasks_requirements() : base("tasks_requirements")
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
         
        public const string ID_REQUIREMENTS = "id_requirements";
        public int IdRequirements
            {
                get
                {
                     return GetValue<int>(ID_REQUIREMENTS);
                }
                set
                {
                    SetValue(ID_REQUIREMENTS, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new tasks_requirements();
        }
    }
}
