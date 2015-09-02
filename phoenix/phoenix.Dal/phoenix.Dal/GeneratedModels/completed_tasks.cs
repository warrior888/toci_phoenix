using System;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class completed_tasks : Model
    {
        public completed_tasks() : base("completed_tasks")
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
         
        public const string ID_LAST_COMPLETED_TASK = "id_last_completed_task";
        public int IdLastCompletedTask
            {
                get
                {
                     return GetValue<int>(ID_LAST_COMPLETED_TASK);
                }
                set
                {
                    SetValue(ID_LAST_COMPLETED_TASK, value);
                }
            }
         
        public const string DATE_OF_TASK_COMPLETION = "date_of_task_completion";
        public DateTime DateOfTaskCompletion
            {
                get
                {
                     return GetValue<DateTime>(DATE_OF_TASK_COMPLETION);
                }
                set
                {
                    SetValue(DATE_OF_TASK_COMPLETION, value);
                }
            }
        

        protected override IModel GetInstance()
        {
            return new completed_tasks();
        }
    }
}
