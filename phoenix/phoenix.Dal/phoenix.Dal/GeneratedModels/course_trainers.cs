using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;

namespace Phoenix.Dal.GeneratedModels
{
    public class course_trainers : Model
    {
        public course_trainers() : base("course_trainers")
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
         
        public const string ID_COURSES_LIST = "id_courses_list";
        public System.Int32 IdCoursesList
            {
                get
                {
                     return GetValue<System.Int32>(ID_COURSES_LIST);
                }
                set
                {
                    SetValue(ID_COURSES_LIST, value);
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
        

        protected override IModel GetInstance()
        {
            return new course_trainers();
        }
    }
}
