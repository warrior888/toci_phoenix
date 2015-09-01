using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class tasks : Model
    {
        public tasks() : base("tasks")
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
         
        public const string TASK_CONTENT = "task_content";
        public string TaskContent
            {
                get
                {
                     return GetValue<string>(TASK_CONTENT);
                }
                set
                {
                    SetValue(TASK_CONTENT, value);
                }
            }
         
        public const string AVERAGE_TIME_MINUTES = "average_time_minutes";
        public int AverageTimeMinutes
            {
                get
                {
                     return GetValue<int>(AVERAGE_TIME_MINUTES);
                }
                set
                {
                    SetValue(AVERAGE_TIME_MINUTES, value);
                }
            }
         
        public const string ID_LESSONS = "id_lessons";
        public int IdLessons
            {
                get
                {
                     return GetValue<int>(ID_LESSONS);
                }
                set
                {
                    SetValue(ID_LESSONS, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new tasks();
        }
    }
}
